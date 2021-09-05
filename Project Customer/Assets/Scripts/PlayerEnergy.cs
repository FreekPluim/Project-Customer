using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{

    [SerializeField] GameObject[] oil;
    [SerializeField] GameObject[] coal;
    [SerializeField] GameObject[] gas;

    [SerializeField] GameObject[] solar;
    [SerializeField] GameObject[] wind;
    [SerializeField] GameObject[] nuclear;

    public float amountOfEnergyOil;
    public float amountOfEnergyCoal;
    public float amountOfEnergyGas;

    public float amountOfEnergySolar;
    public float amountOfEnergyWind;
    public float amountOfEnergyNuclear;

    public Slider energyBarSlider;

    private void Update()
    {
        CheckFactoryCount();
        EnergyBarUpdate();
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


        float total = oilTotal + gasTotal + coalTotal + solarTotal + windTotal + nuclearTotal;
        energyBarSlider.value = total;
    }
}
