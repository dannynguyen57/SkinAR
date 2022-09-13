using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class form_submit : MonoBehaviour
{
    public GameObject name;
    public GameObject email;
    public GameObject phone;
    public GameObject image;
    public GameObject description;

    public string Finalpath;

public void openfile(){

    NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
       {
           
           if (path != null)
           {
            // code ...
            Debug.Log("Image path: " + path);
           }
       }, "Select a PNG image", "image/*");
       Debug.Log("Permission result: " + permission); 
}

public void submit(){

    string Name = name.GetComponent<TMP_InputField>().text;
    string Email = email.GetComponent<TMP_InputField>().text;
    string Phone = phone.GetComponent<TMP_InputField>().text;
    string Description = description.GetComponent<TMP_InputField>().text;
    Debug.Log(Name);
    Debug.Log(Email);
    Debug.Log(Phone);
    Debug.Log(Description);

}

}