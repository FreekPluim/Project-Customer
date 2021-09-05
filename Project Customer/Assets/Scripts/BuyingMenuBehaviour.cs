using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingMenuBehaviour : MonoBehaviour
{
    public GameObject solarPannel;
    public GameObject windmill;
    public GameObject nuclearPowerPlant;

    private void Start()
    {
        //solarPannel = GameObject.FindGameObjectWithTag("SolarPannel");
        solarPannel.SetActive(false);
        windmill.SetActive(false);
        nuclearPowerPlant.SetActive(false);

    }

    private void FixedUpdate()
    {
        if (Input.mousePosition.x > transform.position.x + 140)
        {
            if (Input.GetButton("Fire1"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void OnSolarPressed()
    {
        solarPannel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnWindPressed()
    {
        windmill.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnNuclearPressed()
    {
        nuclearPowerPlant.SetActive(true);
        gameObject.SetActive(false);
    }
}
