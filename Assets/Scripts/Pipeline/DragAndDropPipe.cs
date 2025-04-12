using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragAndDropPipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isUse;



    public void OnPointerDown(PointerEventData eventData)
    {
        isUse = true;
        PipeController.ActivePipe = gameObject;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUse = false;
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            if (isUse)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    transform.position = touch.position;
                }
            }
        }
    }

}
