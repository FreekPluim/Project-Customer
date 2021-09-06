using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public float money;

    public Text uiMoney;

    public float oilPrice, gasPrice, coalPrice;
    public float solarPrice, windPrice, nuclearPrice;

    private void Start()
    {
        money = 10000;
    }

    private void Update()
    {
        uiMoney.text = money.ToString();
    }

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
}
