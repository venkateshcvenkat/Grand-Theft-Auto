using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class spawn : MonoBehaviour
{
    public float time;
    public GameObject loading, playerminimap, hint, arrow;
    bool timebool=false;
    public Animator anim;
    void Start()
    {
       loading.SetActive(false);
        anim = GetComponent<Animator>();
        playerminimap.SetActive(false);
        arrow.SetActive(false);   
        hint.SetActive(false);
    }

   
    void Update()
    {
        time += Time.deltaTime;
        //  int minutes = Mathf.FloorToInt(time / 60);
        //  int seconds = Mathf.FloorToInt(time % 60);

        if (time >= 40 && timebool==false)
        {
           
            Debug.Log("time");
           
            loading.SetActive(true);
           
            StartCoroutine(job());
        }
    }
    IEnumerator job()
    {

        yield return new WaitForSeconds(5);
        loading.SetActive(false);
       
        timebool = true;
        anim.SetBool("talkphone", true);

        yield return new WaitForSeconds(20);
        anim.SetBool("talkphone", false);
        // playerminimap.SetActive(true);
        hint.SetActive(true);
        Destroy(hint,3);
        arrow.SetActive(true);
    }
}
