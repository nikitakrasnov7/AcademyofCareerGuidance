
using TMPro;
using UnityEngine;

public class InformationButtonLB : MonoBehaviour
{

    public BrandLB BrandButton;

    public void GetStringButton(string title)
    {
        GetComponent<TextMeshProUGUI>().text = title;
        int i = 0;

        foreach (string str in ControllerLB.S_ButtonTitle) 
        {
            if(title == str)
            {
                BrandButton = ControllerLB.S_ListBrands[i];
            }
            i++;
        }
    }
}
