using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Photo : MonoBehaviour
{
    public KeyCode screenshotKey;
    public Camera _camera;
    public int fileCounter;

   [SerializeField] public Collide co;
    void Start()
    {
        _camera = GetComponent<Camera>();
        co=GetComponent<Collide>();
    }

    private void LateUpdate()
    {
       
            Capture();
       
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

