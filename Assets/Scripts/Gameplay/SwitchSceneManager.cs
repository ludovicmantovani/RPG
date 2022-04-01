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

        // Création des zombies
        PlayerPrefs.SetInt("Zombini", 30);

        // Allez au jeu
        GoToGame();
    }

    public void GoToGame()
    {
        //Si localisation enregistrée, on la récupère
        //Si non c'est que l'on commence une nouvelle partie
        string sceneName = PlayerPrefs.GetString("Localisation", "Infirmerie");
        SceneManager.LoadScene(sceneName);
    }

    public void GotoGallery()
    {
        SceneManager.LoadScene("Galerie");
    }

    public void GotoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        if (_player)
        {
            // Sauvegarde
            PlayerPrefs.SetString("Localisation", SceneManager.GetActiveScene().name);
        }
        Application.Quit();
    }

    private void Start()
    {
        //Si présence du player dans la scene
        if (_player)
        {
            //Sauvegarde de la localisation
            PlayerPrefs.SetString("Localisation", SceneManager.GetActiveScene().name);
        }
        if (_continueButton)
        {
            if (PlayerPrefs.HasKey("Localisation")) //Si présence d'une sauvegarde
                _continueButton.interactable = true; // On active le bouton continuer
        }
    }
}
