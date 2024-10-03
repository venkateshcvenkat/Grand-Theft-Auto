using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;
    public GameObject police,helipad,minimap,bucati,arrow,finisharrow;

    void Start()
    {
        animator.GetComponent<Animator>();
        police.SetActive(false);
        minimap.SetActive(false);
        helipad.SetActive(false);
        bucati.SetActive(false);
        arrow.SetActive(true);
        finisharrow.SetActive(false);
    }

  
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.Play("dooropen");
            Debug.Log("open");
            bucati.SetActive(true);
            police.SetActive(true);
            minimap.SetActive(true) ;
            helipad.SetActive(true) ;
            arrow.SetActive(false) ;
            finisharrow.SetActive(true) ;
        }
    }
}
