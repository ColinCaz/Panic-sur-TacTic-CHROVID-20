using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject Minimap;
    public GameObject Map;

    public GameObject borderGun;
    public Image backgroundGun;
    public GameObject borderGrenade;
    public Image backgroundGrenade;

    public AudioClip mapSound;
    public AudioSource source;

    void Update()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("[1]"))
        {
            borderGrenade.SetActive(false);
            backgroundGrenade.color = new Color(1,1,1,0.5f);
            borderGun.SetActive(true);
            backgroundGun.color = new Color(1, 1, 1, 1);
        }
        if (Input.GetKeyDown("2") || Input.GetKeyDown("[2]"))
        {
            borderGun.SetActive(false);
            backgroundGun.color = new Color(1, 1, 1, 0.5f);
            borderGrenade.SetActive(true);
            backgroundGrenade.color = new Color(1, 1, 1, 1);
        }
        if ((Input.GetKeyDown("m") || Input.GetKeyDown("tab")) && Time.timeScale != 0)
        {
            source.volume = (float)PlayerPrefs.GetInt("VolumeSons") / 100;
            source.PlayOneShot(mapSound);
            Minimap.SetActive(false);
            Map.SetActive(true);
        }
        if ((Input.GetKeyUp("m") || Input.GetKeyUp("tab")) && Time.timeScale != 0)
        {
            Map.SetActive(false);
            Minimap.SetActive(true);
        }
    }
}
