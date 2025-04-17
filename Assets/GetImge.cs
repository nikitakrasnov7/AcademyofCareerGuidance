using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GetImge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ///*SetImageInSlot*/();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetImageInSlot()
    {
        var base64String = PlayerPrefs.GetString($"\\Image_{TestScreen.FileCounter-1}");
        //Debug.Log( base64String );
        var fileName = Application.persistentDataPath + "\\Image_1.png";
        
       //var bytes = File.ReadAllBytes(fileName);
        byte[] imageData = System.Convert.FromBase64String(base64String);

        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(imageData))
        {
            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f), 
                100f 
            );

            Image renderer = gameObject.GetComponent<Image>();
            if (renderer != null)
            {
                renderer.sprite = sprite;
            }
        }
        else
        {
        }
    }
}