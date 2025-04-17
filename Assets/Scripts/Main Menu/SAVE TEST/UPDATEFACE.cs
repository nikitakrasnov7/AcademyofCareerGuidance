using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPDATEFACE : MonoBehaviour
{
    public TestSaveSO testSaveSo;
    public List<Image> ElementFace;

    

    private void Update()
    {
        //if(Input.touchCount == 1)
        //{
        //    if(Input.GetTouch(0).phase == TouchPhase.Began )
        //    {
        //        GetFacePhoto();
        //    }
        //}
    }
    public void GetFacePhoto()
    {
        if (testSaveSo != null)
        {
            for (int i = 0; i < ElementFace.Count; i++)
            {
                ElementFace[i].sprite = testSaveSo.ListSpriteSaveToFace[i];
            }
        }
    }

    public void SetFacePhoto()
    {
        testSaveSo.ListSpriteSaveToFace.Clear();
        if(ElementFace != null)
        {
            for (int i = 0; i < ElementFace.Count; i++)
            {
                testSaveSo.ListSpriteSaveToFace.Add(ElementFace[i].sprite);
            }
        }
    }
}
