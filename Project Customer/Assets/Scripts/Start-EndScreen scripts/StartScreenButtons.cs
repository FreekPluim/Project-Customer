using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButtons : MonoBehaviour
{
    AudioManager audio;
    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    public void OnPlayButtonPress()
    {
        audio.Play("Menubuttonclick");
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonPress()
    {
        audio.Play("Menubuttonclick");
        Application.Quit();
    }
}
