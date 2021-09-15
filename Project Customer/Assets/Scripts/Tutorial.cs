using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Image text1;
    [SerializeField] Image text2;
    [SerializeField] Image text3;
    [SerializeField] Image text4;

    [SerializeField] GameObject buyingMenu;
    PlayerEnergy energy;
    PlayerPopularity popularity;

    float timer1 = 5f;
    float timer2 = 5f;
    float timer3 = 5f;

    private void Start()
    {
        buyingMenu = GameObject.FindGameObjectWithTag("BuyingMenu");
        energy = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerEnergy>();
        popularity = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerPopularity>();
    }

    private void Update()
    {
        if(timer1 > 0)
        {
            timer1 -= Time.deltaTime;
        }

        if(timer1 <= 0 && text1.gameObject.activeSelf)
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
        }

        if (text2.gameObject.activeSelf)
        {
            if (buyingMenu.activeSelf)
            {
                text2.gameObject.SetActive(false);
                Debug.Log("Text2 inactive!");
            }
        }

        if(energy.greenTotal >= 6 && timer2 > 0)
        {
            text3.gameObject.SetActive(true);
            timer2 -= Time.deltaTime;
        }

        if(timer2 <= 0 && text3.gameObject.activeSelf)
        {
            text4.gameObject.SetActive(true);
            text3.gameObject.SetActive(false);
        }

        if(timer3 > 0 && text4.gameObject.activeSelf)
        {
            timer3 -= Time.deltaTime;
        }

        if(timer3 <= 0 && text4.gameObject.activeSelf)
        {
            if(energy.greenTotal >= 6)
            {
                popularity.tutorialOver = true;
            }
            text4.gameObject.SetActive(false);
        }
    }
}
