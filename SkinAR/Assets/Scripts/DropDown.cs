using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DropDown : MonoBehaviour
{
    public TextMeshProUGUI output;
    public Button Mybutton;
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            output.text = "A";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (val == 1)
        {
            output.text = "Test 1";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (val == 2)
        {
            output.text = "Test 2";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (val == 3)
        {
            output.text = "Test 3";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
    
}
