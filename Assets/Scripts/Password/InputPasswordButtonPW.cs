using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPasswordButtonPW : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ControllerPW.InputPasswordButton(GetComponentInChildren<TextMeshProUGUI>().text);
    }
 
}
