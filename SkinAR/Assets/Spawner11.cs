
using UnityEngine;

public class Spawner11 : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Sdd()
    {
    
      GameObject skinss = Instantiate(GameManager.instance.currentPopupcode.prefab, new Vector3(0,0,1), Quaternion.identity);
        // transform.position
        if (skinss.transform.tag == "popup")
        {
            Destroy(GameObject.FindWithTag("popup2"));
            Destroy(GameObject.FindWithTag("popup3"));
        }
        if (skinss.transform.tag == "popup2")
        {
            Destroy(GameObject.FindWithTag("popup"));
            Destroy(GameObject.FindWithTag("popup3"));
        }
        if (skinss.transform.tag == "popup3")
        {
            Destroy(GameObject.FindWithTag("popup2"));
            Destroy(GameObject.FindWithTag("popup"));
        }

    }

    

    
}
