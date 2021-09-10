using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnergyPlacingBehaviour : MonoBehaviour
{
    private GameObject moneyManager;
    private GameObject builder;

    [SerializeField] GameObject Windmill;
    [SerializeField] GameObject solarPanel;
    [SerializeField] GameObject nuclearEnergy;

    private float price;

    private void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData");
        builder = GameObject.FindGameObjectWithTag("Builder");
        if (gameObject.name == "WindMillHover") 
        { 
            price = moneyManager.GetComponent<PlayerMoney>().windPrice;
            builder.GetComponent<Controls>().building = Windmill;
            builder.GetComponent<Controls>().previewPlaced = false;
        }
        if (gameObject.name == "SolarPanelHover")
        {
            price = moneyManager.GetComponent<PlayerMoney>().solarPrice;
            builder.GetComponent<Controls>().building = solarPanel;
            builder.GetComponent<Controls>().previewPlaced = false;
        }
        if (gameObject.name == "NuclearHover")
        {
            price = moneyManager.GetComponent<PlayerMoney>().nuclearPrice;
            builder.GetComponent<Controls>().building = nuclearEnergy;
            builder.GetComponent<Controls>().previewPlaced = false;
        }
    }



    // Update is called once per frame
    /*void Update()
    {
        transform.position = Input.mousePosition;


        if (gameObject.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                float entryPoint;

                if (plane.Raycast(ray, out entryPoint))
                {
                    moneyManager.GetComponent<PlayerMoney>().RemoveMoney(price);
                    Instantiate(Prefab, ray.GetPoint(entryPoint), Prefab.transform.rotation);
                    gameObject.SetActive(false);
                }

            }
        }
    }*/
}
