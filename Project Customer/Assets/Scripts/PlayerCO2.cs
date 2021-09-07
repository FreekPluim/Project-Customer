using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCO2 : MonoBehaviour
{
    [SerializeField] GameObject[] oil;
    [SerializeField] GameObject[] coal;
    [SerializeField] GameObject[] gas;

    public float amountOfPolutionOil;
    public float amountOfPolutionCoal;
    public float amountOfPolutionGas;

    public Slider co2BarSlider;

    float totalOilPs;
    float totalCoalPs;
    float totalGasPs;
    float totalPolution;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PolutionPs());
    }

    // Update is called once per frame
    void Update()
    {
        CheckFactoryCount();
        CO2IncreasePerSecondCalculation();
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

    IEnumerator PolutionPs()
    {
        if (co2BarSlider != null) co2BarSlider.value += totalPolution;
        Debug.Log("Increased by <b>" + totalPolution + "</b>");
        yield return new WaitForSeconds(1);
        StartCoroutine(PolutionPs());
    }


}
