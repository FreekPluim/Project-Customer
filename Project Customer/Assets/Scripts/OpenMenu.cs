using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    GameObject buyingMenu;

    private void Start()
    {
        buyingMenu = GameObject.FindGameObjectWithTag("BuyingMenu");
        buyingMenu.SetActive(false);
    }

    public void OnButtonPress()
    {
        buyingMenu.SetActive(true);
    }
}
