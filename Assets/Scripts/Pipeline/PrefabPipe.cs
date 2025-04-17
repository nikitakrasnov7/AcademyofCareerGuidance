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

        Vector2 screenPos = gameObject.transform.position; // Изменено на Vector2
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        newPipe.transform.parent = gameObject.transform;
        newPipe.transform.position = worldPos;
        newPipe.transform.localScale = new Vector3(1,1,1);
    }
}
