
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickLogoLB : MonoBehaviour, IPointerClickHandler
{
    bool test;
    bool test2;
    public void OnPointerClick(PointerEventData eventData)
    {
        ControllerLB.SelectLogo = gameObject;
        test = true;
        test2 = true;



    }
    private void Update()
    {
        if (test)
        {
            if (ControllerLB.SelectLogo != null)
            {
                if (ControllerLB.SelectLogo == gameObject)
                {
                    if (test2)
                    {
                        test2 = false;
                        GetComponent<Outline>().enabled = true;
                        GetComponent<Outline>().effectColor = Color.yellow;
                    }


                }
                else
                {
                    test = false;
                    GetComponent<Outline>().enabled = false;
                }

            }

        }
    }
}
