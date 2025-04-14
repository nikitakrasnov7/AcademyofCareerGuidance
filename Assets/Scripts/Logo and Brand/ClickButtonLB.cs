
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickButtonLB : MonoBehaviour, IPointerClickHandler
{
    bool test;
    bool test2;
    public void OnPointerClick(PointerEventData eventData)
    {
        ControllerLB.SelectButton = gameObject;
        test = true;
        test2 = true;



    }
    private void Update()
    {
        if (test)
        {
            if (ControllerLB.SelectButton != null)
            {
                if (ControllerLB.SelectButton == gameObject)
                {
                    if (test2)
                    {
                        test2 = false;
                        GetComponentInParent<Outline>().enabled = true;
                        GetComponentInParent<Outline>().effectColor = Color.yellow;
                    }


                }
                else
                {
                    test = false;
                    GetComponentInParent<Outline>().enabled = false;
                }

            }

        }
    }
}