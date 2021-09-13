using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanelPlacingBehaviour : MonoBehaviour
{
    public GameObject Prefab;
    private GameObject moneyManager;

    private float price;

    private void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData");
        price = moneyManager.GetComponent<PlayerMoney>().solarPrice;
    }

    // Update is called once per frame
    void Update()
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
                    Instantiate(Prefab, new Vector3(ray.GetPoint(entryPoint).x, ray.GetPoint(entryPoint).y + Prefab.transform.localScale.y / 2, ray.GetPoint(entryPoint).z), Prefab.transform.rotation);
                    gameObject.SetActive(false);
                }

            }
        }
    }
}
