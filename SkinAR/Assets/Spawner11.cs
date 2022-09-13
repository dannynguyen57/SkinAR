
using UnityEngine;

public class Spawner11 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Sdd()
    {
    
         Instantiate(GameManager.instance.currentPopupcode.prefab, transform.position, Quaternion.identity);
         
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
                if (hit.transform.tag == "popup")
                {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                }
            }
            else
            {
                Touch myTouch = Input.GetTouch(0);
               // MakeSkin(myTouch);
            }
        }

    }
}
