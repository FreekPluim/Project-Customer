using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInfo : MonoBehaviour
{
    GameObject linkedObject;
    GameObject playerData;

    float destroyPrice;

    AudioManager sound;

    private void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("PlayerData");

        if (GameObject.FindObjectOfType<AudioManager>() != null) sound = GameObject.FindObjectOfType<AudioManager>();

        if(linkedObject == null)
        {
            gameObject.SetActive(false);
        }

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
        destroyPrice = price;
    }

    public void OnBuyDestroyButtonPress()
    {
         if (linkedObject != null)
         {
             if (playerData.GetComponent<PlayerMoney>().money >= destroyPrice)
             {
                Destroy(linkedObject);
                playerData.GetComponent<PlayerMoney>().RemoveMoney(destroyPrice);
                sound.Play("destroying");
                gameObject.SetActive(false);
            }
             else
             {
                 Debug.Log("Not Enough Money");
             }
         }
    }
}
