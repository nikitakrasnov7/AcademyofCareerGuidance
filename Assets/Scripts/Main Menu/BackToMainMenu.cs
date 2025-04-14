
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
        SceneManager.LoadScene("2");
        SceneManager.UnloadSceneAsync(nameActiveScene);
    }
}
