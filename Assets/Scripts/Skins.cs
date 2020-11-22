using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skins : MonoBehaviour
{
    public void Retour()
    {
        StartCoroutine(SoundAndReturn());
    }

    IEnumerator SoundAndReturn()
    {
        float time = Time.timeScale;
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.075f);
        SceneManager.UnloadSceneAsync("Skins");
        Time.timeScale = time;
    }
}
