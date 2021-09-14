using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] Text requiredText;
    [SerializeField] Text productionText;

    float newEnergyRequired;
    float expectedRequired;
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

    public float solarBoost;
    public float windBoost;

    float oilTotal;
    float gasTotal;
    float coalTotal;

    float solarTotal;
    float windTotal;
    float nuclearTotal;

    bool energySet = false;

    CloseInfo closeInfo;

    public Slider energyBarSlider;
    private void Start()
    {
        newEnergyRequired = 6;
    }

    private void FixedUpdate()
    {
        CheckFactoryCount();
        EnergyBarUpdate();

        if (pollutingTotal == 0)
        {
            pollutingEnergy();
        }

        if (expectedRequired == 0)
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
        oilTotal = amountOfEnergyOil * oil.Length;
        gasTotal = amountOfEnergyGas * gas.Length;
        coalTotal = amountOfEnergyCoal * coal.Length;

        solarTotal = amountOfEnergySolar * solar.Length;
        windTotal = amountOfEnergyWind * wind.Length;
        nuclearTotal = amountOfEnergyNuclear * nuclear.Length;

        greenTotal = solarTotal + windTotal + nuclearTotal;
        pollutingTotal = oilTotal + gasTotal + coalTotal;
        float total = oilTotal + gasTotal + coalTotal + solarTotal + windTotal + nuclearTotal;
        requiredText.text = "Required: " + newEnergyRequired;
        productionText.text = "Producing: " + greenTotal.ToString();
    }

    public void pollutingEnergy()
    {
/*        oil = GameObject.FindGameObjectsWithTag("OilRefinery");
        coal = GameObject.FindGameObjectsWithTag("CoalBurner");
        gas = GameObject.FindGameObjectsWithTag("GasProcessingPlant");

        oilTotal = amountOfEnergyOil * oil.Length;
        gasTotal = amountOfEnergyGas * gas.Length;
        coalTotal = amountOfEnergyCoal * coal.Length;

        

        Debug.Log("total" + pollutingTotal);*/
    }
}
