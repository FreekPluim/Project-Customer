using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
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
    [SerializeField] float baseIncome;
    [SerializeField] float popularityModifier;
    [SerializeField] float currentIncome;
    [SerializeField] float incomeTimer = 30;
    

    private void Start()
    {
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
