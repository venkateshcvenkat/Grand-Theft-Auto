using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public GameObject Negro;
    public Animator Animator;
    public Transform player;
    bool attack;

    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;
    public bool isloop = true;
    void Start()
    {
        Animator = GetComponent<Animator>();    
    }

   
    void Update()
    {
       if (attack == true)
       {

            transform.LookAt(player.transform.position);
            speed = 0;
       }

       Vector3 destination = waypoints[index].transform.position;
       Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
       transform.position = newPos;
        transform.LookAt (destination);
        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.05)
        {
            if(index < waypoints.Count-1)
            {
                index++;
            }
            else
            {
                if(isloop)
                {
                    index = 0;
                }
            }
        }
    }
    IEnumerator action()
    {
        yield return new WaitForSeconds(3);
       // transform.LookAt(camera.transform.position);
        Animator.SetBool("Attack", false);
        attack = false;
        Negro.gameObject.GetComponent<Transform>().rotation = Quaternion.identity;
       
        Debug.Log("enter");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            attack = true;
            
            Animator.SetBool("Attack", true);
            
            Debug.Log("touch");
            StartCoroutine(action());
    
        }
        
    }

}
