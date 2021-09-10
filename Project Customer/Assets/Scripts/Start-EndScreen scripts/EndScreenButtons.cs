using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour
{
    public void OnReplayButtonPress()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }
}
