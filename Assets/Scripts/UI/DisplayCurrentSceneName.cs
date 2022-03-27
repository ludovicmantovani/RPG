using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayCurrentSceneName : MonoBehaviour
{
    private Text _text;
    void Start()
    {
        //Récupération et assignation du nom de la scene au champ texte
        if (TryGetComponent<Text>(out _text))
            _text.text = SceneManager.GetActiveScene().name;
    }
}
