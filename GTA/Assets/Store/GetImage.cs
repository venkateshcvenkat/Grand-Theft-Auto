using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using Object = System.Object;

public class AssetGameObjectGetter : MonoBehaviour
{
    public string resourcePath; // The path to the asset file inside the Resources folder
    public GameObject[] loadedObjects;
   
  
    public Image[] textures;
    public GameObject[] imageBuffer;
    

    private void Start()
    {


     

        object textures = Resources.LoadAll<Texture2D>(resourcePath);
       
    }

    private void Update()
    {
       loadedObjects=Resources.LoadAll<GameObject>(resourcePath);


    }


    private void GetAssetGameObjects()
    {
         loadedObjects = Resources.LoadAll<GameObject>(resourcePath);

        if (loadedObjects != null && loadedObjects.Length > 0)
        {
            foreach (GameObject obj in loadedObjects)
            {
                // Do something with the loaded game object
                Debug.Log("Loaded GameObject: " + obj.name);
            }
        }
        else
        {
            Debug.LogError("No game objects found in the asset file: " + resourcePath);
        }
    }
}
