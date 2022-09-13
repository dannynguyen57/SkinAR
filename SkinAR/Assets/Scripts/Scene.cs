
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Scene : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    //public TextMeshProUGUI display_name;
    public void PlayGame(int sceneIndex)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        StartCoroutine(LoadAsynchrounously(sceneIndex));
    }

    IEnumerator LoadAsynchrounously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

       // yield return new WaitForSeconds(3);
        
        
       
        while(!operation.isDone)
        {
            float progressV = Mathf.Clamp01(operation.progress / 0.9f);
           //Debug.Log(progress);
          // yield return new WaitForSeconds(3);


          

           slider.value = progressV;
           progressText.text = progressV * 100f + "%";
           //yield return new WaitForSeconds(3);
           yield return null;
        }
        
      
        
    }

    // public void Awake()
    // {
    //     display_name.text = "Hi " + Inputname.inputname.player_name + "!";
    // }
    
}