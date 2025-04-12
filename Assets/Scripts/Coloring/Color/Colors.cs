using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Colors : MonoBehaviour, IPointerClickHandler
{
    public Color color;
    private void Start()
    {
        ActiveColor.activeColor = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ActiveColor.activeColor = color;
    }
}
