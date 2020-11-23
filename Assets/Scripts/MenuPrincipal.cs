using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Text nombreDeFragmentDeVirus;
    public GameObject help;

    public GameObject fragVirus;
    public GameObject tutoriel;
    public GameObject aide;
    public GameObject quitter;
    public GameObject solo;
    public GameObject coop;
    public GameObject skins;
    public GameObject options;

    public Text helpText;

    public AudioClip backButtonSound;
    public AudioSource source;

    void Start()
    {
        nombreDeFragmentDeVirus.text = PlayerPrefs.GetInt("FragVirus", 0).ToString();
    }

    public void Help()
    {
        help.SetActive(true);

        fragVirus.SetActive(true);
        tutoriel.SetActive(true);
        aide.SetActive(false);
        quitter.SetActive(true);
        solo.SetActive(true);
        coop.SetActive(true);
        skins.SetActive(true);
        options.SetActive(true);

        helpText.text = "Ceci est le bouton sur lequel vous venez de cliquer : le bouton aide." + System.Environment.NewLine +
            "Cliquez dessus si vous avez un doute sur l'utilité des boutons du menu principal." + System.Environment.NewLine +
            "Pour quitter l'aide, vous pouvez appuyer sur le bouton \"FERMER L'AIDE\" ou sur la touche \"ECHAP\" à tout moment.";
    }

    public void Next()
    {
        if (!aide.activeInHierarchy)
        {
            aide.SetActive(true);
            tutoriel.SetActive(false);
            helpText.text = "Cliquez sur ce bouton pour lancer le tutoriel." + System.Environment.NewLine +
                "Il vous apprendra tout ce qu'il faut savoir pour bien commencer" + System.Environment.NewLine +
                "à jouer sur de bonnes bases !";
        }
        else if (!tutoriel.activeInHierarchy)
        {
            tutoriel.SetActive(true);
            fragVirus.SetActive(false);
            helpText.text = "Ce nombre représente les fragments de virus en votre possession." + System.Environment.NewLine +
                "Les fragments de virus servent uniquement à acheter des skins," + System.Environment.NewLine +
                "ils s'obtiennent à la fin de chaque ville en fonction de vos performances.";
        }
        else if (!fragVirus.activeInHierarchy)
        {
            fragVirus.SetActive(true);
            solo.SetActive(false);
            helpText.text = "Cliquez sur ce bouton pour lancer une partie en solo." + System.Environment.NewLine +
                "La population TacTic compte sur vous pour les protéger !";
        }
        else if (!solo.activeInHierarchy)
        {
            solo.SetActive(true);
            coop.SetActive(false);
            helpText.text = "Cliquez sur ce bouton pour lancer une partie en multijoueur." + System.Environment.NewLine +
                "Vous et vos amis allez devoir coopérer pour sauver la planète TacTic !";
        }
        else if (!coop.activeInHierarchy)
        {
            coop.SetActive(true);
            skins.SetActive(false);
            helpText.text = "Ce bouton vous permet d'accéder à la boutique des skins." + System.Environment.NewLine +
                "Servez vous des fragments de virus que vous avez récoltés pour faire vos achats !";
        }
        else if (!skins.activeInHierarchy)
        {
            skins.SetActive(true);
            options.SetActive(false);
            helpText.text = "Pour accéder aux options du jeu, cliquez sur ce bouton." + System.Environment.NewLine +
                "Les options sont aussi accessibles en jeu depuis le menu pause.";
        }
        else if (!options.activeInHierarchy)
        {
            options.SetActive(true);
            quitter.SetActive(false);
            helpText.text = "Si vous souhaitez quitter le jeu," + System.Environment.NewLine +
                "appuyez sur ce bouton.";
        }
        else if (!quitter.activeInHierarchy)
        {
            quitter.SetActive(true);
            helpText.text = "L'aide est terminée !" + System.Environment.NewLine +
                "N'hésitez pas à revenir pour vous rafraîchir la mémoire.";
        }
        else
        {
            FinHelp();
        }
    }

    public void FinHelp()
    {
        help.SetActive(false);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && help.activeInHierarchy)
        {
            source.volume = (float)PlayerPrefs.GetInt("VolumeSons") / 100;
            source.PlayOneShot(backButtonSound);
            FinHelp();
        }
    }
}
