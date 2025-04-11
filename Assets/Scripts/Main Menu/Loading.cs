using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadingGame());
    }

    private IEnumerator LoadingGame()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("aaa");
        SceneManager.LoadScene("2");
        SceneManager.UnloadSceneAsync("1");

        //SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
    }
}
