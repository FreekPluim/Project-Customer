using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPopularity : MonoBehaviour
{
    public float currentPopularity = 500;
    float calculatedPopularity;
    public float maxPopularity = 1000;

    float modifierPopularity;
    float currentPopularityForBar;
    public Image greenBar;


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
    }
}
