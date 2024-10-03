using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ui : MonoBehaviour
{
    public float speed=-100f;
   
    void Start()
    {
       
    }

  
    void Update()
    {
      transform.Rotate(0,0,speed*Time.deltaTime);
    }
   
}
