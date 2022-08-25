using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Inputname : MonoBehaviour
{
    public static Inputname inputname;
    public TMP_InputField inputField;

    public string player_name;

    private void Awake()
    {
        if (inputname == null)
        {
            inputname = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName()
    {
        player_name = inputField.text;
        SceneManager.LoadSceneAsync("HomePage");
        

    }

}
