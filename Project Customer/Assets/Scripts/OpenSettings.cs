using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    public bool settingsOpen;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            settingsOpen = !settingsOpen;
            settingsMenu.SetActive(settingsOpen);
        }   
    }
}
