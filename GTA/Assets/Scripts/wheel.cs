using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    public GameObject fl;
    public GameObject fr;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fl.transform.SetParent(gameObject.transform);
        fr.transform.SetParent(gameObject.transform);
    }
 
    
      
}
