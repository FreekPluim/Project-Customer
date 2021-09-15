using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingMenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Windmill;
    [SerializeField] GameObject solarPanel;
    [SerializeField] GameObject nuclearEnergy;
    [SerializeField] GameObject trees;

    private GameObject builder;
    private GameObject moneyManager;

    [HideInInspector] public bool placingWind = false;
    [HideInInspector] public bool placingSolar = false;
    [HideInInspector] public bool placingTrees = false;

    private void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData");
        builder = GameObject.FindGameObjectWithTag("Builder");
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
        if (moneyManager.GetComponent<PlayerMoney>().money >= moneyManager.GetComponent<PlayerMoney>().solarPrice)
        {
            moneyManager.GetComponent<PlayerMoney>().RemoveMoney(moneyManager.GetComponent<PlayerMoney>().solarPrice);
            builder.GetComponent<Controls>().building = solarPanel;
            builder.GetComponent<Controls>().previewPlaced = false;
            builder.GetComponent<Controls>().isBuilding = true;
            placingSolar = true;
            gameObject.SetActive(false);
        }
    }

    public void OnWindPressed()
    {
        if (moneyManager.GetComponent<PlayerMoney>().money >= moneyManager.GetComponent<PlayerMoney>().windPrice)
        {
            moneyManager.GetComponent<PlayerMoney>().RemoveMoney(moneyManager.GetComponent<PlayerMoney>().windPrice);
            builder.GetComponent<Controls>().building = Windmill;
            builder.GetComponent<Controls>().previewPlaced = false;
            builder.GetComponent<Controls>().isBuilding = true;
            placingWind = true;
            gameObject.SetActive(false);
        }
    }

    public void OnNuclearPressed()
    {
        if (moneyManager.GetComponent<PlayerMoney>().money >= moneyManager.GetComponent<PlayerMoney>().nuclearPrice)
        {
            moneyManager.GetComponent<PlayerMoney>().RemoveMoney(moneyManager.GetComponent<PlayerMoney>().nuclearPrice);
            builder.GetComponent<Controls>().building = nuclearEnergy;
            builder.GetComponent<Controls>().previewPlaced = false;
            builder.GetComponent<Controls>().isBuilding = true;
            gameObject.SetActive(false);
        }
    }

    public void OnTreesPressed()
    {
        if (moneyManager.GetComponent<PlayerMoney>().money >= moneyManager.GetComponent<PlayerMoney>().nuclearPrice)
        {
            moneyManager.GetComponent<PlayerMoney>().RemoveMoney(moneyManager.GetComponent<PlayerMoney>().treePrice);
            builder.GetComponent<Controls>().building = trees;
            builder.GetComponent<Controls>().previewPlaced = false;
            builder.GetComponent<Controls>().isBuilding = true;
            placingTrees = true;
            gameObject.SetActive(false);
        }
    }
}
