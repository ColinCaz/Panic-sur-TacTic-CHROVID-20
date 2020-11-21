using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChargerScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
        Time.timeScale = 1;
    }

    public void AjouterScene(string Scene)
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Additive);
        if (Scene == "Pause")
        {
            Time.timeScale = 0;
        }
    }

    public void FermerScene(string Scene)
    {
        SceneManager.UnloadSceneAsync(Scene);
        if (Scene == "Pause")
        {
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (SceneManager.GetSceneByName("Skins").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Skins");
            }
            if (SceneManager.GetSceneByName("Options").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Options");
            }
            else if (SceneManager.GetSceneByName("Pause").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Pause");
                Time.timeScale = 1;
            }
        }
    }
}
