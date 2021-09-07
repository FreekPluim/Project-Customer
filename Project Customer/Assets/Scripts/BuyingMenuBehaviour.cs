using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingMenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Windmill;
    [SerializeField] GameObject solarPanel;
    [SerializeField] GameObject nuclearEnergy;

    private GameObject builder;
    private GameObject moneyManager;


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
        moneyManager.GetComponent<PlayerMoney>().RemoveMoney( moneyManager.GetComponent<PlayerMoney>().solarPrice);
        builder.GetComponent<Controls>().building = solarPanel;
        builder.GetComponent<Controls>().previewPlaced = false;
        builder.GetComponent<Controls>().isBuilding = true;
        gameObject.SetActive(false);
    }

    public void OnWindPressed()
    {
        moneyManager.GetComponent<PlayerMoney>().RemoveMoney(moneyManager.GetComponent<PlayerMoney>().windPrice);
        builder.GetComponent<Controls>().building = Windmill;
        builder.GetComponent<Controls>().previewPlaced = false;
        builder.GetComponent<Controls>().isBuilding = true;
        gameObject.SetActive(false);
    }

    public void OnNuclearPressed()
    {
        moneyManager.GetComponent<PlayerMoney>().RemoveMoney(moneyManager.GetComponent<PlayerMoney>().nuclearPrice);
        builder.GetComponent<Controls>().building = nuclearEnergy;
        builder.GetComponent<Controls>().previewPlaced = false;
        builder.GetComponent<Controls>().isBuilding = true;
        gameObject.SetActive(false);
    }
}
