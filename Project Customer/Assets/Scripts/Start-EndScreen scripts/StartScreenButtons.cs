using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButtons : MonoBehaviour
{
    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }
}
