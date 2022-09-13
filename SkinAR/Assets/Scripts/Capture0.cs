
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Capture0 : MonoBehaviour
{
   [Header("Photo Taker")]
   [SerializeField] private RawImage photodis;
  //  [SerializeField] private GameObject photoframe;
    public static Capture0 capture;

    int currentCamIndex = 0;
    public RawImage display;
    //public RawImage display2;
    private WebCamTexture webcamTexture;
    public Texture2D photo;
    private bool viewingphoto;
    
    
    //public GameObject Skin;
   // public List<Sprite> objectList = new List<Sprite>();
    //public float Zooms = 60f;

    void Start()
    {
            //WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            webcamTexture = new WebCamTexture();
            display.texture = webcamTexture;
            webcamTexture.Play();
           // DontDestroyOnLoad(gameObject);
           // Debug.Log(objectList.Count);
    }


    
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
        
        
       
    }

    public void Showpic()
    {
        if(display != null)
        {
           // ShowPhoto();
           
            display.texture = photo;
           // SceneManager.LoadSceneAsync("Capture_1");
                
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
    public void Retry2()
    {
        //RemovePhoto();
        SceneManager.LoadSceneAsync("Capturee");
        display.texture = webcamTexture;
        webcamTexture.Play();

    }
    // private void Awake()
    // {
    //     if (capture == null)
    //     {
    //         capture = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else 
    //     {
    //         Destroy(gameObject);
    //     }

    // }

    

    

    // void Update()
    // {
 
    //     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //     {
 
    //         Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
    //         RaycastHit hit;
 
    //         Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
 
    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             if (hit.transform.tag == "skinz")
    //             {
    //                 GameObject temp = hit.transform.gameObject;
    //                 Destroy(temp);
    //             }
    //         }
    //         else
    //         {
    //             Touch myTouch = Input.GetTouch(0);
    //             MakeSkin(myTouch);
    //         }
    //     }
    // }
 
    // private void MakeSkin(Touch TouchPos)
    // {
    //     Vector3 objPos = Camera.main.ScreenToWorldPoint(TouchPos.position);
    //         objPos.z = -1020;
    //         skin.GetComponent<SpriteRenderer>().sprite = objectList[Random.Range(0, objectList.Count)];
    //         Instantiate(skin, objPos, Quaternion.identity);
    // }

    


    
    
        
    
}
