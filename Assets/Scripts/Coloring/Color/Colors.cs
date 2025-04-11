using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Colors : MonoBehaviour, IPointerClickHandler
{
    public Color color;

    public void OnPointerClick(PointerEventData eventData)
    {
        ActiveColor.activeColor = color;
    }
}
