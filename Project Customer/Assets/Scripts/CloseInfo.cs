using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInfo : MonoBehaviour
{
    GameObject linkedObject;
    GameObject playerData;

    float price;

    private void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("PlayerData");
    }

    private void FixedUpdate()
    {
        if (Input.mousePosition.x < transform.position.x - 140)
        {
            if (Input.GetButton("Fire1"))
            { gameObject.SetActive(false); }
        }
    }

    public void OnCloseButtonPress()
    {
        gameObject.SetActive(false);
    }

    public void LinkObjectAndPrice(GameObject LinkedObject, float price)
    {
        linkedObject = LinkedObject;
    }

    public void OnBuyDestroyButtonPress()
    {
        if (linkedObject != null)
        {
            if (playerData.GetComponent<PlayerMoney>().money >= price)
            {
                Destroy(linkedObject);
                playerData.GetComponent<PlayerMoney>().RemoveMoney(price);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Not Enough Money");
            }
        }
    }

}
