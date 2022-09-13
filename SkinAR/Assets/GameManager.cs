using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   private Vector3 offset;
    private bool dragging = false;
    private float dist;
    private Transform toDrag;
   public Popupcode[] popupcodes;
   public Popupcode currentPopupcode;

   private void Awake()
   {
       if (instance == null)
         {
              instance = this;
         }
         else
         {
              Destroy(gameObject);
         }

         DontDestroyOnLoad(gameObject);
   }

   private void Start()
   {
    if(popupcodes.Length > 0 )
    {
        currentPopupcode = popupcodes[0];
    }
   }

   public void SetPopupcode(Popupcode popupcode)
   {
       currentPopupcode = popupcode;
   }

   void Update()
    {
 
       Vector3 v3;

       if(Input.touchCount != 1)
       {
            dragging = false;
           return;
       }

       Touch touch = Input.touches[0];
       Vector3 pos = touch.position;

       if (touch.phase == TouchPhase.Began)
       {
           Ray ray = Camera.main.ScreenPointToRay(pos);
           RaycastHit hit;

           if (Physics.Raycast(ray, out hit))
           {
                if (hit.collider.tag == "popup")
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                     v3.z = 1;
                    v3.x = 0;
                    v3.y = 0;
                    offset = toDrag.position - v3;
                    dragging = true;

                }
                if (hit.collider.tag == "popup2")
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                     v3.z = 1;
                    v3.x = 0;
                    v3.y = 0;
                    offset = toDrag.position - v3;
                    dragging = true;

                }
                if (hit.collider.tag == "popup3")
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                    v3.z = 1;
                    v3.x = 0;
                    v3.y = 0;
                    offset = toDrag.position - v3;
                    dragging = true;

                }
            }
       }

       if (dragging && touch.phase == TouchPhase.Moved)
       {
           v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
           v3 = Camera.main.ScreenToWorldPoint(v3);
           toDrag.position = v3 + offset;
       }

       if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
       {
           dragging = false;
       }
       

    }
}
