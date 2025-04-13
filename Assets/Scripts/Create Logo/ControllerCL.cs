using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCL : MonoBehaviour
{
    public List<Image> ImageInventary = new List<Image>();
    public List<Sprite> SpriteForImageInventary = new List<Sprite>();

    public GameObject PointerInstatiate;
    public GameObject RightUpPointer;
    public GameObject LeftDownPointer;

    public static GameObject S_RUPointer;
    public static GameObject S_LDPointer;

    public GameObject ColliderEll;
    public GameObject ColliderRect;
    public GameObject ColliderMinRect;
    public GameObject ColliderPol;

    public static GameObject ActiveElement;

    public TextMeshProUGUI PlayerLabel;


    public static List<TriggerCL> Triggers = new List<TriggerCL>();




    List<int> test = new List<int>() { 0, 1, 2, 3 };
    private void Start()
    {
        S_RUPointer = RightUpPointer;
        S_LDPointer = LeftDownPointer;
        RandomingInventary();
    }

    public void RandomingInventary()
    {
        for (int i = 0; i < ImageInventary.Count; i++)
        {
            int random = test[Random.Range(0, test.Count)];
            ImageInventary[i].sprite = SpriteForImageInventary[random];
            test.Remove(random);
        }
        test = new List<int>() { 0, 1, 2, 3 };
    }

    public void CheckLogo()
    {
        if (Triggers.Count > 2)
        {
            int i = 0;
            foreach (TriggerCL trigger in Triggers)
            {
                i = i + trigger.CountTriggers;
            }

            if (i == 0)
            {
                PlayerLabel.text = "бяе бепмн, кнцнрхо янупюмем";
            }
            else
            {
                PlayerLabel.text = "цде рн ньхайю, тхцспш оепеяейючряъ";
            }
        }

    }
}
