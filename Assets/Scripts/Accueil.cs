using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Accueil : MonoBehaviour
{
    public Text bonjour;
    public GameObject demanderNom;
    public InputField nom;
    public GameObject continuer;

    private bool wait = false;

    void Start()
    {
        if(PlayerPrefs.GetString("Nom", "") == "")
        {
            continuer.SetActive(false);
            demanderNom.SetActive(true);
            wait = true;
        }
        else
        {
            bonjour.text = "Bonjour " + PlayerPrefs.GetString("Nom", "");
        }
    }

    public void Nom()
    {
        if(nom.text != "")
        {
            PlayerPrefs.SetString("Nom", nom.text);
            bonjour.text = "Bonjour " + PlayerPrefs.GetString("Nom", nom.text);
            demanderNom.SetActive(false);
            continuer.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.25f);
        wait = false;
    }
    
    void Update()
    {
        if (continuer.activeInHierarchy && Input.anyKeyDown && !wait)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
        continuer.GetComponent<Text>().color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time * 0.5f, 1));
    }
}
