using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finish : MonoBehaviour
{

    public GameObject original, cam,helicopter;
    public bool heli;
    void Start()
    {
       
        cam.SetActive(false);
        helicopter.SetActive(false);
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mission"))
        {
            original.SetActive(false );
            helicopter.SetActive(true);
            cam.SetActive(true);
            StartCoroutine(end());

        }
    }
    IEnumerator end ()
    {
        yield return new WaitForSeconds(5);
        heli = true;
    }
}
