using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationLogo : MonoBehaviour
{
    public BrandLB BrandLogo;

    public void GetSprite(Sprite sprite)
    {
        int i = 0;
        GetComponent<Image>().sprite = sprite;
  

        foreach (Sprite s in ControllerLB.S_ListSpriteForLogo)
        {
            if (s == sprite)
            {
                BrandLogo = ControllerLB.S_ListBrands[i];
                break;
            }
            i++;
        }
    }
}
