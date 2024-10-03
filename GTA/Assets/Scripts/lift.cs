using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lift : MonoBehaviour
{
    public Animator anim;
    public GameObject wall,gate;

    void Start()
    {
        anim.GetComponent<Animator>();
        wall.SetActive(false);
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mission"))
        {
            wall.SetActive(true);
            anim.SetBool("mission", true);
            Debug.Log("lifted");
            Destroy(gate, 10);
        }
    }
}
