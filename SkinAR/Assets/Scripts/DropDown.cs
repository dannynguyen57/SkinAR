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
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (val == 1)
        {
            output.text = "B";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (val == 2)
        {
            output.text = "C";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }

        if (val == 3)
        {
            output.text = "D";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
    }
    
}
