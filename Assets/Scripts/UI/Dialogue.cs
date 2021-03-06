using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Text _textUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(string text, float time = 0)
    {
        StartCoroutine(DisplayText(text, time));
    }

    IEnumerator DisplayText(string text, float seconds)
    {
        _textUI.text = text;
        
        yield return new WaitForSeconds(seconds);
        if (seconds > 0f)
            _textUI.text = "";
    }
}
