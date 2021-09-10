using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    PlayerEnergy energyScript;

    [Header("UI Variables")]
    public float money;
    public Text uiMoney;

    [Space]
    [Header("Prices Building / Destroying Buildings")]
    public float oilPrice;
    public float gasPrice;
    public float coalPrice;
    public float solarPrice;
    public float windPrice;
    public float nuclearPrice;

    [Space]
    [Header("Gameobject References")]
    [SerializeField] GameObject energy;
    [SerializeField] Image popularity;

    [Space]
    [Header("Income variables")]
    float baseIncome;
    [SerializeField] float popularityModifier;
    [SerializeField] float currentIncome;
    float incomeTimer = 10;
    

    private void Start()
    {
        energyScript = gameObject.GetComponent<PlayerEnergy>();
        StartCoroutine(IncomePerMonth());
    }

    private void Update()
    {
        calculateIncome();
        uiMoney.text = money.ToString();    }

    public void GetMoney(float addedMoney)
    {
        // add money
        money += addedMoney;
    }

    public void RemoveMoney(float price)
    {
        // remove money
        money -= price;
    }

    void calculateIncome()
    {
        baseIncome = energyScript.greenTotal * 100;
        Debug.Log(baseIncome);
        popularityModifier = popularity.fillAmount * 2;
        currentIncome = baseIncome * popularityModifier;
    }

    IEnumerator IncomePerMonth()
    {
        GetMoney(currentIncome);
        yield return new WaitForSeconds(incomeTimer);
        StartCoroutine(IncomePerMonth());
    }
}
