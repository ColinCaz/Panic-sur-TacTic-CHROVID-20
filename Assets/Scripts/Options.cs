using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public InputField nom;
    public Slider musiques;
    public Slider sons;

    void Start()
    {
        nom.text = PlayerPrefs.GetString("Nom", "");
        musiques.value = PlayerPrefs.GetInt("VolumeMusiques", 100);
        sons.value = PlayerPrefs.GetInt("VolumeSons", 100);
    }

    public void Nom()
    {
        PlayerPrefs.SetString("Nom", nom.text);
    }

    public void Musiques()
    {
        PlayerPrefs.SetInt("VolumeMusiques", (int)musiques.value);
    }

    public void Sons()
    {
        PlayerPrefs.SetInt("VolumeSons", (int)sons.value);
    }

    public void Retour()
    {
        SceneManager.UnloadSceneAsync("Options");
    }
}