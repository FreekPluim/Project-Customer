using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingMenuBehaviour : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.mousePosition.x > transform.position.x + 193.4f)
        {
            if (Input.GetButton("Fire1"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void OnSolarPressed()
    {
        gameObject.SetActive(false);
    }

    public void OnWindPressed()
    {
        gameObject.SetActive(false);
    }

    public void OnNuclearPressed()
    {
        gameObject.SetActive(false);
    }
}
