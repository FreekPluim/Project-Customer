using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanelPlacingBehaviour : MonoBehaviour
{
    public GameObject Prefab;

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
                    Instantiate(Prefab, new Vector3(ray.GetPoint(entryPoint).x, ray.GetPoint(entryPoint).y + Prefab.transform.localScale.y / 2, ray.GetPoint(entryPoint).z), Prefab.transform.rotation);
                    gameObject.SetActive(false);
                }

            }
        }
    }
}
