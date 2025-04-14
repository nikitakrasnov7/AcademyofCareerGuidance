using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider LoadBar;
    private float f = 0.01f;
    private void Start()
    {
        LoadBar.value = 0;
        StartCoroutine(LoadingGame());

    }

    private IEnumerator LoadingGame()
    {
        while (LoadBar.value <= 1)
        {
            LoadBar.value += f;
            yield return new WaitForSeconds(0.1f);
            if(LoadBar.value >= 1) 
            {
                break;
            }
        }

        if (LoadBar.value >= 1)
        {
            Debug.Log("aaa");

            SceneManager.LoadScene("2");
            SceneManager.UnloadSceneAsync("1");

        }

    }
}
