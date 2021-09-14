using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingMenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Windmill;
    [SerializeField] GameObject solarPanel;
    [SerializeField] GameObject nuclearEnergy;

    private Controls builder;
    private PlayerMoney moneyManager;

    [HideInInspector] public bool placingSolar;
    [HideInInspector] public bool placingWind;

    private void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerMoney>();
        builder = GameObject.FindGameObjectWithTag("Builder").GetComponent<Controls>();
    }

    private void FixedUpdate()
    {
        if (Input.mousePosition.x > transform.position.x + 140)
        {
            if (Input.GetButton("Fire1"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void OnSolarPressed()
    {
        if(moneyManager.money >= moneyManager.solarPrice)
        {
            moneyManager.RemoveMoney(moneyManager.solarPrice);
            builder.building = solarPanel;
            builder.previewPlaced = false;
            builder.isBuilding = true;
            placingSolar = true;
            gameObject.SetActive(false);
        }
    }

    public void OnWindPressed()
    {
        if (moneyManager.money >= moneyManager.windPrice)
        {
            moneyManager.RemoveMoney(moneyManager.windPrice);
            builder.building = Windmill;
            builder.previewPlaced = false;
            builder.isBuilding = true;
            placingWind = true;
            gameObject.SetActive(false);
        }
    }

    public void OnNuclearPressed()
    {
        if (moneyManager.money >= moneyManager.nuclearPrice)
        {
            moneyManager.RemoveMoney(moneyManager.nuclearPrice);
            builder.building = nuclearEnergy;
            builder.previewPlaced = false;
            builder.isBuilding = true;
            gameObject.SetActive(false); 
        }
    }
}
