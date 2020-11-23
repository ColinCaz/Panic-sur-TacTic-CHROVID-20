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
    public GameObject borderTourelle;
    public Image backgroundTourelle;

    public AudioClip mapSound;
    public AudioSource source;

    public Slider contamination;
    public Text taux;

    private bool use1 = true;
    private bool use2 = false;
    private bool use3 = false;

    public void Contamination()
    {
        taux.text = contamination.value.ToString() + "%";
    }

    void Update()
    {
        if (use1)
        {
            if (Input.mouseScrollDelta.y < 0)
            {
                use1 = false;
                use2 = true;
            }
            else if (Input.mouseScrollDelta.y > 0)
            {
                use1 = false;
                use3 = true;
            }
        }
        else if (use2)
        {
            if (Input.mouseScrollDelta.y < 0)
            {
                use2 = false;
                use3 = true;
            }
            else if (Input.mouseScrollDelta.y > 0)
            {
                use2 = false;
                use1 = true;
            }
        }
        else if (use3)
        {
            if (Input.mouseScrollDelta.y < 0)
            {
                use3 = false;
                use1 = true;
            }
            else if (Input.mouseScrollDelta.y > 0)
            {
                use3 = false;
                use2 = true;
            }
        }
        if (Input.GetKeyDown("1") || Input.GetKeyDown("[1]") || use1)
        {
            borderGrenade.SetActive(false);
            backgroundGrenade.color = new Color(1,1,1,0.5f);
            borderTourelle.SetActive(false);
            backgroundTourelle.color = new Color(1, 1, 1, 0.5f);
            borderGun.SetActive(true);
            backgroundGun.color = new Color(1, 1, 1, 1);
        }
        if (Input.GetKeyDown("2") || Input.GetKeyDown("[2]") || use2)
        {
            borderGun.SetActive(false);
            backgroundGun.color = new Color(1, 1, 1, 0.5f);
            borderTourelle.SetActive(false);
            backgroundTourelle.color = new Color(1, 1, 1, 0.5f);
            borderGrenade.SetActive(true);
            backgroundGrenade.color = new Color(1, 1, 1, 1);
        }
        if (Input.GetKeyDown("3") || Input.GetKeyDown("[3]") || use3)
        {
            borderGun.SetActive(false);
            backgroundGun.color = new Color(1, 1, 1, 0.5f);
            borderGrenade.SetActive(false);
            backgroundGrenade.color = new Color(1, 1, 1, 0.5f);
            borderTourelle.SetActive(true);
            backgroundTourelle.color = new Color(1, 1, 1, 1);
        }
        Debug.Log(Input.mouseScrollDelta.y);
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
