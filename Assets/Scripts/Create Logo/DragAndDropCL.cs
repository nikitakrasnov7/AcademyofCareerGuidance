using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropCL : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isUse;
    float xx;
    float yy;

    public void OnPointerDown(PointerEventData eventData)
    {
        isUse = true;
        //ControllerCL.ActiveElement = gameObject;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUse = false;
    }
    float testDis = 0;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            if (isUse)
            {
                Touch touch = Input.GetTouch(0);
                
                transform.position = touch.position; 

            }
        }
    }

}

