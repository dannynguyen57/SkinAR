using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Inputname2 : MonoBehaviour
{
    public TextMeshProUGUI display_name;

    public string player_name;

    public void Awake()
    {
        display_name.text = "Hi " + Inputname.inputname.player_name + "!";
    }

}
