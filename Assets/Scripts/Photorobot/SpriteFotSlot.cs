using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteFotSlot : MonoBehaviour, IPointerClickHandler
{
    public CreateRandomPhoto createPhoto;

    public void OnPointerClick(PointerEventData eventData)
    {
        createPhoto.CollectingPhotorobot(GetComponent<Image>().sprite);
        createPhoto.ActiveCheckButton();
    }
}
