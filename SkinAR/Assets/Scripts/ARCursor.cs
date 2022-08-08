
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    public GameObject Childobj;
    public GameObject objtoplace;
    public ARRaycastManager raycast;

   public bool useCursor = true;
    // Start is called before the first frame update
   void Start()
    {
        Childobj.SetActive(useCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if(useCursor)
        {
            UpdateCursor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (useCursor)
            {
                    GameObject.Instantiate(objtoplace, transform.position, transform.rotation);
            }

            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                raycast.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                    if (hits.Count > 0)
                {
                    GameObject.Instantiate(objtoplace, hits[0].pose.position, hits[0].pose.rotation);
                }
            }
       }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycast.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
