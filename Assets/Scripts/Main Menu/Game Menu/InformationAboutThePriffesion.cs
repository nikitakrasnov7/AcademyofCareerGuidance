using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Main Menu/Game Menu/ProfData")]
public class InformationAboutThePriffesion : ScriptableObject
{
    public Sprite IconProffesion;
    public string LabelProffesion;
    public string DescriptionProffesion;

    public List<string> ListMiniGame = new List<string>();

}
