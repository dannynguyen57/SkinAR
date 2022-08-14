using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Capture0 : MonoBehaviour
{
    int currentCamIndex = 0;
    public RawImage display;
    private WebCamTexture webcamTexture;

    public void CamClick()
    {
        if(WebCamTexture.devices.Length > 0 )
        {
            currentCamIndex += 1;
            currentCamIndex &= WebCamTexture.devices.Length;

        }
    }

    public void CamStop ()
    {
        if (webcamTexture != null)
        {
            display.texture = null;
            webcamTexture.Stop();
            webcamTexture = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            webcamTexture = new WebCamTexture(device.name);
            display.texture = webcamTexture;
            webcamTexture.Play();
        }
    }
        
    
}
