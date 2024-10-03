using FCG;
using MTAssets.EasyMinimapSystem;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class EnterExit : MonoBehaviour
{
    public Transform player;
    public Transform car;
    public RCC_CarControllerV3 carcontroller;
    bool playerin, isdriving;
    public GameObject rcccam,maincam,Duplicate;
    public MinimapRenderer Dupminimap;
    public TrafficCar trafficcar;
    public spawn spwnscript;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        carcontroller.enabled = false;
        trafficcar.enabled = true;
        rcccam.SetActive(false);
        maincam.SetActive(true);
        Duplicate.SetActive(false);
       

        Dupminimap.gameObject.SetActive(false);
      
        
    }

   
    void Update()
    {
        Dupminimap = FindObjectOfType<MinimapRenderer>();
        if (Input.GetKeyDown(KeyCode.E) && playerin)
        {
           
            player.transform.SetParent(car);
            
            player.gameObject.SetActive(false);
            Duplicate.SetActive(true);
            carcontroller.enabled = true;
            trafficcar.enabled = false;
            isdriving = true;
            rcccam.SetActive(true);
            maincam.SetActive(false );
           
            spwnscript.playerminimap.SetActive(false);
            Dupminimap.gameObject.SetActive(true );
           
        }
        if (Input.GetKeyDown(KeyCode.Q) && isdriving)
        {
            player.transform.SetParent(null);
           
            Duplicate.SetActive(false);
            player.gameObject.SetActive(true);
            carcontroller.enabled = false;
            trafficcar.enabled = true;
            isdriving = false;
            rcccam.SetActive(false);
            maincam.SetActive(true);
            spwnscript.playerminimap.SetActive(true);
            Dupminimap.gameObject.SetActive(false);

        }
       

        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerin = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerin = false;
        }
    }
}
