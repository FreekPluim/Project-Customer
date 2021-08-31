using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    Button cleanButton;

    GameObject infectedArea;

    GameObject getOther;

    // Start is called before the first frame update
    void Start()
    {
        cleanButton = GameObject.FindGameObjectWithTag("CleanButton").GetComponent<Button>();
        infectedArea = GameObject.FindGameObjectWithTag("InfectedArea");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (infectedArea != null)
        {
            if (other == infectedArea.GetComponent<Collider>())
            {
                cleanButton.interactable = true;
                getOther = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (infectedArea != null)
        {
            if (other == infectedArea.GetComponent<Collider>())
            {
                cleanButton.interactable = false;
                getOther = null;
            }
        }
    }

    public void Clean()
    {
        if(getOther != null) Destroy(getOther);
    }

    
}
