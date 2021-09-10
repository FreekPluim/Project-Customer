using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] Text requiredText;
    [SerializeField] Text productionText;

    float energyRequired;
    float newEnergyRequired;
    float expectedRequired;
    float energyProducing;
    float pollutingTotal;
    public float greenTotal;

    GameObject[] oil;
    GameObject[] coal;
    GameObject[] gas;

    GameObject[] solar;
    GameObject[] wind;
    GameObject[] nuclear;

    [Space]
    [Header("Energy Production floats")]
    public float amountOfEnergyOil;
    public float amountOfEnergyCoal;
    public float amountOfEnergyGas;

    public float amountOfEnergySolar;
    public float amountOfEnergyWind;
    public float amountOfEnergyNuclear;

    public Slider energyBarSlider;
    private void Start()
    {
        newEnergyRequired = 6;
        //energyRequired += pollutingTotal;
    }

    private void Update()
    {
        CheckFactoryCount();
        EnergyBarUpdate();

        if(expectedRequired == 0)
        {
            expectedRequired = pollutingTotal;
        }

        if(expectedRequired != pollutingTotal)
        {
            float difference = expectedRequired - pollutingTotal;
            newEnergyRequired += difference;
            Debug.Log(difference);
            expectedRequired = pollutingTotal;
        }
    }

    private void CheckFactoryCount()
    {
        oil = GameObject.FindGameObjectsWithTag("OilRefinery");
        coal = GameObject.FindGameObjectsWithTag("CoalBurner");
        gas = GameObject.FindGameObjectsWithTag("GasProcessingPlant");

        solar = GameObject.FindGameObjectsWithTag("SolarPannel");
        wind = GameObject.FindGameObjectsWithTag("Windmill");
        nuclear = GameObject.FindGameObjectsWithTag("NuclearPowerPlant");
    }

    void EnergyBarUpdate()
    {
        float oilTotal = amountOfEnergyOil * oil.Length;
        float gasTotal = amountOfEnergyGas * gas.Length;
        float coalTotal = amountOfEnergyCoal * coal.Length;
        
        float solarTotal = amountOfEnergySolar * solar.Length;
        float windTotal = amountOfEnergyWind * wind.Length;
        float nuclearTotal = amountOfEnergyNuclear * nuclear.Length;

        greenTotal = solarTotal + windTotal + nuclearTotal;
        pollutingTotal = oilTotal + gasTotal + coalTotal;
        float total = oilTotal + gasTotal + coalTotal + solarTotal + windTotal + nuclearTotal;
        //energyBarSlider.value = total;
        SetEnergyTexts();
    }

    void SetEnergyTexts()
    {
        requiredText.text = "Required: " + newEnergyRequired;
        productionText.text = "Producing: " + greenTotal.ToString();
    }
}
