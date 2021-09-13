using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPopularity : MonoBehaviour
{
    public float currentPopularity = 500;
    public float maxPopularity = 1000;

    public float decreaseWindmillDistance;
    public float decreaseNuclearDistance;

    public Image popularityBar;
    [SerializeField] PlayerEnergy playerEnergy;

    float calculatedPopularity;
    float energyModifier;

    float oldRequired;
    float oldProducing;

    bool tutorialOver;

    private void Start()
    {
        playerEnergy = transform.GetComponentInParent<PlayerEnergy>();

        oldRequired = playerEnergy.energyRequired;
        oldProducing = playerEnergy.greenTotal;
    }

    

    void CalculateEnergyModifier()
    {
        if(playerEnergy.energyRequired != oldRequired && playerEnergy.energyRequired >= playerEnergy.greenTotal) 
        {
            float difference = playerEnergy.energyRequired - oldRequired;
            DecreasePopularity(difference * 50);
        }
        if (playerEnergy.greenTotal != oldProducing)
        {
            float difference = playerEnergy.greenTotal - oldProducing;
            IncreasePopularity(difference * 50);
        }
        oldRequired = playerEnergy.energyRequired;
        oldProducing = playerEnergy.greenTotal;
    }

    void CalculatePopularity()
    {
        calculatedPopularity = currentPopularity / maxPopularity;
    }

    public void IncreasePopularity(float IncreasePopularity)
    {
        Debug.Log("<b>Increased</b> by: <b>" + IncreasePopularity + "</b>");
        currentPopularity += IncreasePopularity;
    }

    public void DecreasePopularity(float DecreasePopularity)
    {
        Debug.Log("<b>Decreased</b> by: <b>" + DecreasePopularity + "</b>");
        currentPopularity -= DecreasePopularity;
    }
    void SetSlider()
    {
        popularityBar.fillAmount = calculatedPopularity;

        if (calculatedPopularity <= 0.3f)
        {
            popularityBar.color = Color.red;
        } else if (calculatedPopularity <= 0.7f)
        {
            popularityBar.color = Color.yellow;
        }
        else
        {
            popularityBar.color = Color.green;
        }
        
    }
    private void Update()
    {
        CalculatePopularity();
        SetSlider();

        if(currentPopularity <= 0)
        {
            SceneManager.LoadScene(2);
        }
        if (playerEnergy.greenTotal >= 6) tutorialOver = true;
        if (tutorialOver)
        {
            if (playerEnergy.energyRequired != oldRequired || playerEnergy.greenTotal != oldProducing)
            {
                CalculateEnergyModifier();
            }
        }
    }
}
