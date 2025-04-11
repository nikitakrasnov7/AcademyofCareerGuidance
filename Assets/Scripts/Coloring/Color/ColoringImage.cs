using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColoringImage : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(ActiveColor.activeColor != null)
        {
            GetComponent<Image>().color = ActiveColor.activeColor;
        }
    }

    private void Start()
    {
        GetComponent<Image>().color = new Color(255, 250, 250, 0);
    }
}
