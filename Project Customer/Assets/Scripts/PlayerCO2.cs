using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCO2 : MonoBehaviour
{
    GameObject[] oil;
    GameObject[] coal;
    GameObject[] gas;
    public Slider co2BarSlider;
    [SerializeField] Image co2Bar;

    [Space]
    [Header("Polution Amounts float")]
    public float amountOfPolutionOil;
    public float amountOfPolutionCoal;
    public float amountOfPolutionGas;
    public float amountOfDecreaseTrees;

    float totalOilPs;
    float totalCoalPs;
    float totalGasPs;
    float totalPolution;

    float currentCO2;
    float calaculatedCO2;

    void Start()
    {
        StartCoroutine(PolutionPs());
        co2Bar.fillAmount = 0.5f;
        currentCO2 = co2BarSlider.maxValue / 2;
    }

    void Update()
    {
        CheckFactoryCount();
        CO2IncreasePerSecondCalculation();

        if (co2Bar.fillAmount * co2BarSlider.maxValue >= co2BarSlider.maxValue)
        {
            SceneManager.LoadScene(2);
        }
        
        calaculatedCO2 = currentCO2 / co2BarSlider.maxValue;

        Debug.Log("TotalCO2: " + calaculatedCO2);
    }

    private void CheckFactoryCount()
    {
        oil = GameObject.FindGameObjectsWithTag("OilRefinery");
        coal = GameObject.FindGameObjectsWithTag("CoalBurner");
        gas = GameObject.FindGameObjectsWithTag("GasProcessingPlant");
    }

    void CO2IncreasePerSecondCalculation()
    {
        totalOilPs = amountOfPolutionOil * oil.Length;
        totalCoalPs = amountOfPolutionCoal * coal.Length;
        totalGasPs = amountOfPolutionGas * gas.Length;
        totalPolution = totalCoalPs + totalOilPs + totalGasPs;
    }

    public void DecreaseCO2(float decrease)
    {
        co2Bar.fillAmount -= decrease;
    }

    IEnumerator PolutionPs()
    {
        //if (co2BarSlider != null) co2BarSlider.value += totalPolution;
        currentCO2 += totalPolution;
        co2Bar.fillAmount = calaculatedCO2;
        //Debug.Log("Increased by <b>" + totalPolution + "</b>");
        yield return new WaitForSeconds(1);
        StartCoroutine(PolutionPs());
    }

    


}
