using GLTFast.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class helicapter : MonoBehaviour
{
    public GameObject complete;
    public List<GameObject> waypoints;
    public finish finishsecript;
    public float speed = 2;
    int index = 0;
    void Start()
    {
        complete.SetActive(false);
    }

  
    void Update()
    {
        if (finishsecript.heli==true)
        {
            Vector3 destination = waypoints[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;
            transform.LookAt(destination);
            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                if (index < waypoints.Count - 1)
                {
                    index++;

                }

            }
        }
        StartCoroutine(win());
    }
    IEnumerator win()
    {
        yield return new WaitForSeconds(3);
        complete.SetActive(true);
    }
}
