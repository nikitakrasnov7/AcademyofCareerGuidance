using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMiniGame : MonoBehaviour, IPointerClickHandler
{
    public string NameMiniGameScene;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(NameMiniGameScene != null)
        {
            SceneManager.LoadScene(NameMiniGameScene);
            SceneManager.UnloadSceneAsync("2");
        }
    }
}
