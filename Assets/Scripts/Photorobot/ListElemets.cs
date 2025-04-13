using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListElemets : MonoBehaviour, IPointerClickHandler
{
    public TypeElementPhotorobot TypeElement;
    public List<Sprite> Sprites = new List<Sprite>();

    public UnityEvent ActiveInventery;

    public void OnPointerClick(PointerEventData eventData)
    {
        CreateRandomPhoto.ActiveTypeElement = TypeElement;
        CreateRandomPhoto.NewSpriteForInventary = Sprites;
        ActiveInventery.Invoke();
        //CreateRandomPhoto.UpdateInventary();

    }
}
