using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skins : MonoBehaviour
{
    public void Retour()
    {
        SceneManager.UnloadSceneAsync("Skins");
    }
}
