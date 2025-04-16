
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ColoringImage : MonoBehaviour
{
    public List<ColorSprite> Sprites = new List<ColorSprite>();
    public TextMeshProUGUI txt;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 screenPos = touch.position; // »зменено на Vector2
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos); // »зменено на Vector2

                RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 0f); // »спользуем Physics2D.Raycast

                if (hit) // ѕроверка на hit.collider.tag уже не нужна, так как hit возвращает null, если ничего не найдено.
                {
                    if (hit.collider.tag == "Image")
                    {
                        hit.collider.GetComponent<SpriteRenderer>().color = ActiveColor.activeColor;
                        hit.collider.GetComponent<ColorSprite>().CurrentColor = ActiveColor.activeColor;

                    }
                }
                Debug.DrawRay(worldPos, Camera.main.transform.forward * 100f, Color.red, 2f); //направление луча изменено
            }
        }
    }

    public void CheckingColors()
    {
        int i = 0;
        foreach (var sprite in Sprites)
        {
            if (sprite.CheckingForColorMatching())
            {
                i++;
            }
        }
        if (i == Sprites.Count)
        {
            txt.text = "все норм";
            Debug.Log("все норм");
        }
        else
        {

            txt.text = "что то не так";
            Debug.Log("что то не так");
        }
    }
}
