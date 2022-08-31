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
    
    
    public GameObject skin;
    public List<Sprite> objectList = new List<Sprite>();
    //public float Zooms = 60f;

    
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

    

        photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();

        
        byte[] bytes = photo.EncodeToPNG();
        
        File.WriteAllBytes(Application.dataPath + "/../Photo.png", bytes);
        ShowPhoto();
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        // {
 
        //     Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        //     RaycastHit hit;
 
        //     Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
 
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         if (hit.transform.tag == "skinz")
        //         {
        //             GameObject temp = hit.transform.gameObject;
        //             Destroy(temp);
        //         }
        //     }
        //     else
        //     {
        //         Touch myTouch = Input.GetTouch(0);
        //         Showpic(myTouch);
        //     }
        // }
        
       
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
            Debug.Log(objectList.Count);
    }

    void Update()
    {
 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
 
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
 
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
 
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "skinz")
                {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                }
            }
            else
            {
                Touch myTouch = Input.GetTouch(0);
                MakeSkin(myTouch);
            }
        }
    }
 
    private void MakeSkin(Touch TouchPos)
    {
        Vector3 objPos = Camera.main.ScreenToWorldPoint(TouchPos.position);
            objPos.z = -1020;
            skin.GetComponent<SpriteRenderer>().sprite = objectList[Random.Range(0, objectList.Count)];
            Instantiate(skin, objPos, Quaternion.identity);
    }

    


    
    
        
    
}
