using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorSprite : MonoBehaviour
{
    public Color CorrectColor;

    public Color CurrentColor;

    public bool CheckingForColorMatching()
    {
        Debug.Log(gameObject.name + "  " + CorrectColor.ToString() + "  " + CurrentColor.ToString());
        if (CurrentColor == CorrectColor)
        {
            return true;
        }
        else if (CurrentColor != CorrectColor)
        {
            return false;
        }
        return false;

    }
}
