using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Capture0 : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private RawImage photodis;
  //  [SerializeField] private GameObject photoframe;

    int currentCamIndex = 0;
    public RawImage display;
    private WebCamTexture webcamTexture;
    private Texture2D photo;
    private bool viewingphoto;

    public void CamClick()
    {
       // if(WebCamTexture.devices.Length > 0 )
       // {
        //    currentCamIndex += 1;
        //    currentCamIndex &= WebCamTexture.devices.Length;

        //}
        currentCamIndex = (currentCamIndex + 1) %
        WebCamTexture.devices.Length;
        // Change camera only works if the camera is
        webcamTexture.Stop ();
        webcamTexture.deviceName = WebCamTexture.devices[currentCamIndex].name;
        webcamTexture.Play ();
    }

    public void CamStop ()
    {
        if (webcamTexture != null)
        {
            display.texture = null;
            webcamTexture.Stop();
            webcamTexture = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            webcamTexture = new WebCamTexture(device.name);
            display.texture = webcamTexture;
            webcamTexture.Play();
        }
    }

    public void takephoto ()
        {
           
                if(!viewingphoto)
                {
                    StartCoroutine(TakePhoto());
                }
                else
                {
                    RemovePhoto();                
                }
          

            
           
        }
   

    IEnumerator TakePhoto()  // Start this Coroutine on some button click
    {
        viewingphoto = true;
    

        yield return new WaitForEndOfFrame(); 

    

        photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();

        
        byte[] bytes = photo.EncodeToPNG();
        
        File.WriteAllBytes(Application.dataPath + "/../Photo.png", bytes);
        ShowPhoto();
       
    }

    void ShowPhoto()
    {
        Texture2D photo2 = new Texture2D(webcamTexture.width, webcamTexture.height);
        photodis.texture = photo;
        

       // photoframe.SetActive(true);

    }

    void RemovePhoto()
    {
        viewingphoto = false;
        
       // photoframe = false;
    }

    public void Retry()
    {
        RemovePhoto();
        display.texture = webcamTexture;
        webcamTexture.Play();

    }

    
    
        
    
}
