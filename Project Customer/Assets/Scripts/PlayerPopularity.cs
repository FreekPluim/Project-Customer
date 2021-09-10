using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPopularity : MonoBehaviour
{
    public float currentPopularity = 500;
    public float maxPopularity = 1000;
    public Image greenBar;
    [SerializeField] PlayerEnergy playerEnergy;

    float calculatedPopularity;
    float energyModifier;

    private void Start()
    {
        playerEnergy = transform.GetComponentInParent<PlayerEnergy>();
    }

    void CalculateEnergyModifier()
    {
        
    }

    void CalculatePopularity()
    {
        calculatedPopularity = currentPopularity / maxPopularity;
    }

    public void IncreasePopularity(float IncreasePopularity)
    {
        currentPopularity += IncreasePopularity;
    }

    public void DecreasePopularity(float DecreasePopularity)
    {
        currentPopularity -= DecreasePopularity;
    }
    void SetSlider()
    {
        greenBar.fillAmount = calculatedPopularity;

        if (calculatedPopularity <= 0.3f)
        {
            greenBar.color = Color.red;
        } else if (calculatedPopularity <= 0.7f)
        {
            greenBar.color = Color.yellow;
        }
        else
        {
            greenBar.color = Color.green;
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
    }
}
