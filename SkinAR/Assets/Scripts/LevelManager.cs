using System.Threading;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    private float _target;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName) {
        _target = 0;
       
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        do{
            await Task.Delay(100);
            _target = scene.progress;

        } while (scene.progress < 0.9f);
        await Task.Delay(1000);
        scene.allowSceneActivation = true;
        loadingScreen.SetActive(false);
    }

    void Update()
    {
      //  loadingScreen.value = Mathf.MoveToward(_target,3 * Time.deltaTime);
    }
}
