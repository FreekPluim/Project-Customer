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
    }
}
