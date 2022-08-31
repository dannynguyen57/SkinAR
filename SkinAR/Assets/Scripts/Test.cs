
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public List<Sprite> objectList = new List<Sprite>();
    public GameObject skin;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(objectList.Count);
    }

    // Update is called once per frame
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
