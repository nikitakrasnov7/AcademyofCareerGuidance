using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrefabPipe : MonoBehaviour, IPointerDownHandler
{
   public GameObject Prefab;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject newPipe =  Instantiate(Prefab);
        newPipe.transform.parent = gameObject.transform;
        newPipe.transform.position = eventData.position;
    }
}
