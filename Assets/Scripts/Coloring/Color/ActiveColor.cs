using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColor : MonoBehaviour
{
    public static Color activeColor;
    private void Start()
    {
        activeColor = Color.white;
    }
}
