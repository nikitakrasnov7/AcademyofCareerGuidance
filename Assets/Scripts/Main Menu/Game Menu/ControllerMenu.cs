using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ControllerMenu : MonoBehaviour
{
    public GameObject PrefabMiniGameButton;
    public GameObject ParentToPrefabMiniGameButton;

    public GameObject InformationPanel;
    public Image Icon;
    public TextMeshProUGUI Label;
    public TextMeshProUGUI Discription;

    int countScreen;

    

    public void OpenWindowForProfession(InformationAboutThePriffesion so)
    {
        InformationPanel.SetActive(true);

        Icon.sprite = so.IconProffesion;
        Label.text = so.LabelProffesion;
        Discription.text = so.DescriptionProffesion;

        for(int i = 0; i<so.ListMiniGame.Count; i++)
        {

            GameObject newButtonMiniGame = Instantiate(PrefabMiniGameButton);
            newButtonMiniGame.transform.parent = ParentToPrefabMiniGameButton.transform;
            newButtonMiniGame.transform.GetComponentInChildren<TextMeshProUGUI>().text = $"{i+1}";
            newButtonMiniGame.AddComponent<StartMiniGame>();
            newButtonMiniGame.GetComponent<StartMiniGame>().NameMiniGameScene = so.ListMiniGame[i];
            Debug.Log(newButtonMiniGame.name);
        }

    }

    public void BackToListProffesions()
    {

        InformationPanel.SetActive(false);
        int i = ParentToPrefabMiniGameButton.transform.childCount;
        for(int j = 0; j < i; j++)
        {
            Destroy(ParentToPrefabMiniGameButton.transform.GetChild(j).gameObject);
        }
    }

    //public void TestScreenshot()
    //{
    //    countScreen++;
    //     ScreenCapture.CaptureScreenshot($"Assets/Images/Screenshots/screenTest{countScreen}.png");
    //    Debug.Log($"Assets/Images/Screenshots/screenTest{countScreen}.png");
    //}


    

}
