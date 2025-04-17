
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    private static BackToMainMenu instance;
    public static BackToMainMenu Instance 
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<BackToMainMenu>();
            }
            return instance;
        }
    }

    public void BackToMenu(string nameActiveScene)
    {
        SceneManager.LoadScene("Menu button");

        SceneManager.LoadScene("2", LoadSceneMode.Additive);

        SceneManager.UnloadSceneAsync(nameActiveScene);
    }
}
