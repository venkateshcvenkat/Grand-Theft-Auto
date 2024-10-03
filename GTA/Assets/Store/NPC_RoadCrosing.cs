using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class NPC_RoadCrosing : MonoBehaviour
{
    public GameObject ray;
    NavMeshAgent agent;
    Animator ani;
    Rigidbody rb;
    npcIndividual napcindividual;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        napcindividual = GetComponent<npcIndividual>();

       // agent.speed = 1.8f;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,3))
        {
            if (hit.collider.gameObject.tag == "Stop")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                ani.SetBool("move", false);
                agent.enabled = false;
                napcindividual.enabled = false;

            }
            else
            {
               
               
            }
         
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.red);
            napcindividual.enabled = true;
            agent.enabled = true;
            ani.SetBool("move", true);

        }
    }
}
