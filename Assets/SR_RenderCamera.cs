using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SR_RenderCamera : MonoBehaviour {

    public int FileCounter = 0;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CamCapture();   
        }
    }

    void CamCapture()
    {
        Camera Cam = GetComponent<Camera>();

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);
        
        Debug.Log(Bytes);
        
        string base64String = System.Convert.ToBase64String(Bytes);
        PlayerPrefs.SetString("\\Image_" + FileCounter, base64String);

        File.WriteAllBytes(Application.persistentDataPath   + FileCounter + ".png", Bytes);
        FileCounter++;
    }
   
}
