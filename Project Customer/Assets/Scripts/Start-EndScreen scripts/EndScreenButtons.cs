using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour
{
    AudioManager audio;

    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    public void OnReplayButtonPress()
    {
        audio.Play("Menubuttonclick");
        SceneManager.LoadScene(0);
    }

    public void OnQuitButtonPress()
    {
        audio.Play("Menubuttonclick");
        Application.Quit();
    }
}
