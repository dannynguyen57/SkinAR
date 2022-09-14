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
    //public RawImage display2;
    private WebCamTexture webcamTexture;
    private Texture2D photo;
    private bool viewingphoto;
    public float Zooms = 60f;

    
    public void CamClick()
    {
       // if(WebCamTexture.devices.Length > 0 )
       // {
        //    currentCamIndex += 1;
        //    currentCamIndex &= WebCamTexture.devices.Length;

        //}
        currentCamIndex = (currentCamIndex + 1) %
        WebCamTexture.devices.Length;
        
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
        //yield return new WaitForSeconds(5);

    

        photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();

        
        byte[] bytes = photo.EncodeToPNG();
        
        File.WriteAllBytes(Application.dataPath + "/../Photo.png", bytes);
        ShowPhoto();
       
    }

    public void Showpic()
    {
        if(display != null)
        {
           // ShowPhoto();
            display.texture = photo;
        }
        else
        {
            //RemovePhoto();
            display.texture = webcamTexture;
            webcamTexture.Play();
        }

        
    }

    void ShowPhoto()
    {
        //Texture2D photo2 = new Texture2D(webcamTexture.width, webcamTexture.height);
        photodis.texture = photo;
        display.texture = photo;
        

       // photoframe.SetActive(true);

    }

    void RemovePhoto()
    {
        viewingphoto = false;
        display.texture = webcamTexture;
        webcamTexture.Play();
        
       // photoframe = false;
    }

    public void Retry()
    {
        RemovePhoto();
        display.texture = webcamTexture;
        webcamTexture.Play();

    }

    

    void Start()
    {
            //WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            webcamTexture = new WebCamTexture();
            display.texture = webcamTexture;
            webcamTexture.Play();
    }

    


    
    
        
    
}
