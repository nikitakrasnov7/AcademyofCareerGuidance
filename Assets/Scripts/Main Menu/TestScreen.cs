

using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TestScreen : MonoBehaviour
{
    public static int FileCounter = 0;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            takeHiResShot = true;

            CamCapture();
        }
    }

    private bool takeHiResShot = false;


    public void CamCapture()
    {

        Camera Cam = GetComponent<Camera>();

        RenderTexture rt = new RenderTexture(250, 250, 24);
        Camera.main.targetTexture = rt;


        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        RenderTexture.active = rt;
        Cam.Render();


        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();

        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        Debug.Log(Bytes);

        string base64String = System.Convert.ToBase64String(Bytes);
        PlayerPrefs.SetString("\\Image_" + FileCounter, base64String);

      File.WriteAllBytes(Application.persistentDataPath + "\\Image_" + ".png", Bytes);
        FileCounter++;
        takeHiResShot = false;

        Debug.Log(FileCounter);
    }

}
