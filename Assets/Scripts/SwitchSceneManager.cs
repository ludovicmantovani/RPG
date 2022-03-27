using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class SwitchSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Button _continueButton;


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NewGame()
    {
        // Effacement des player pref
        PlayerPrefs.DeleteAll();

        // Allez au jeu
        GoToGame();
    }

    public void GoToGame()
    {
        //Si localisation enregistr�e, on la r�cup�re
        //Si non c'est que l'on commence une nouvelle partie
        string sceneName = PlayerPrefs.GetString("Localisation", "Infirmerie");
        SceneManager.LoadScene(sceneName);
    }

    public void GotoGallery()
    {
        SceneManager.LoadScene("Galerie");
    }

    public void Exit()
    {
        if (_player)
        {
            // Sauvegarde
        }
        Application.Quit();
    }

    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        //Si pr�sence du player dans la scene
        if (_player)
        {
            //On sauvegarde la localisation
        }
        if (_continueButton)
        {
            //Si pr�sence d'une sauvegarde
            //Activation du bouton
            _continueButton.interactable = true;
        }
    }
}
