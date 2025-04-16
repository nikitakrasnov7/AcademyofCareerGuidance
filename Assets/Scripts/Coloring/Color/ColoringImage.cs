
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
                Vector2 screenPos = touch.position; // �������� �� Vector2
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos); // �������� �� Vector2

                RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 0f); // ���������� Physics2D.Raycast

                if (hit) // �������� �� hit.collider.tag ��� �� �����, ��� ��� hit ���������� null, ���� ������ �� �������.
                {
                    if (hit.collider.tag == "Image")
                    {
                        hit.collider.GetComponent<SpriteRenderer>().color = ActiveColor.activeColor;
                        hit.collider.GetComponent<ColorSprite>().CurrentColor = ActiveColor.activeColor;

                    }
                }
                Debug.DrawRay(worldPos, Camera.main.transform.forward * 100f, Color.red, 2f); //����������� ���� ��������
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
            txt.text = "��� ����";
            Debug.Log("��� ����");
        }
        else
        {

            txt.text = "��� �� �� ���";
            Debug.Log("��� �� �� ���");
        }
    }
}
