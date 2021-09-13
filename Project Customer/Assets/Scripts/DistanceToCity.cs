using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToCity : MonoBehaviour
{
    [SerializeField] bool isToCLose = false;
    bool isDecreased = false;

    [SerializeField] GameObject playerData;

    public void IsToClose(bool tempIsToClose)
    {
        playerData = GameObject.FindGameObjectWithTag("PlayerData");
        isToCLose = tempIsToClose;
        //Debug.Log("function is called");
    }

    private void Update()
    {
        if (isToCLose && !isDecreased)
        {
            Debug.Log("Function called on: " + gameObject.name);
            if (this.CompareTag("Windmill"))
            {
                Debug.Log("Function called on: " + gameObject.name);
                playerData.GetComponent<PlayerPopularity>().DecreasePopularity(playerData.GetComponent<PlayerPopularity>().decreaseWindmillDistance);
                isDecreased = true;
            }

            if (this.CompareTag("NuclearPowerPlant"))
            {
                Debug.Log("Function called on: " + gameObject.name);
                playerData.GetComponent<PlayerPopularity>().DecreasePopularity(playerData.GetComponent<PlayerPopularity>().decreaseNuclearDistance);
                isDecreased = true;
            }
        }
    }
}
