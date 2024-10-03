using FCG;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class Collide : MonoBehaviour
{
    [SerializeField]public int damage;
    [SerializeField]public int trafficSingnal;

    public Sprite mySprite;
    public Camera _camera;
    public int fileCounter;

    public GameObject[] loadedObjects;
    public string resourcePath;
    private void Update()
    {
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        

        damage ++;
        Capture();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            Debug.Log("Stop");
            trafficSingnal += 1;
        }
    }

    public void Capture()
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        Debug.Log(_camera);
        RenderTexture.active = _camera.targetTexture;

        _camera.Render();
        Debug.Log("enter");

        Texture2D image = new Texture2D(_camera.targetTexture.width, _camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, _camera.targetTexture.width, _camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = activeRenderTexture;

        
       byte[] bytes = image.EncodeToPNG();
        Destroy(image);

        Debug.Log(bytes);

       
        File.WriteAllBytes(Application.dataPath + "/Image/" + fileCounter + ".png", bytes);
      
        
        fileCounter++;

       
    }
 
}
