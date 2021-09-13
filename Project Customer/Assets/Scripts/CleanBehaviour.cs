using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanBehaviour : MonoBehaviour
{
    GameObject player;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("player");
        button.interactable = false;
    }

    public void OnButtonPressed()
    {
        if(player != null) player.GetComponent<PlayerInteraction>().Clean();
        button.interactable = false;
    }
}
