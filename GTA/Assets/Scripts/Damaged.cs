using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    public float health = 30f;
    public GameObject losspanel;
    void Start()
    {
        losspanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("police"))
        {
            TakeDamge(10);
            
        }
    }
    public void TakeDamge(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("health over");
            losspanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
