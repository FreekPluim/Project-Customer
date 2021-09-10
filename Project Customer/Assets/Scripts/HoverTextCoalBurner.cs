using UnityEngine;

public class HoverTextCoalBurner : MonoBehaviour
{
    [SerializeField] GameObject coalBurnerText;
    GameObject moneyManager;
    GameObject coalInfo;
    float price;

    private void Awake()
    {
        coalInfo = GameObject.FindGameObjectWithTag("CoalInfo");
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData");
    }

    // Start is called before the first frame update
    void Start()
    {
        coalBurnerText.SetActive(false);
        coalInfo.SetActive(false);
        price = moneyManager.GetComponent<PlayerMoney>().coalPrice;
    }

    private void Update()
    {
        coalBurnerText.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 15, Input.mousePosition.z); ;
    }

    public void OnMouseOver()
    {
        coalBurnerText.SetActive(true);
        if (Input.GetButtonUp("Fire1"))
        {
            coalInfo.GetComponent<CloseInfo>().LinkObjectAndPrice(gameObject, price);
            coalInfo.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        coalBurnerText.SetActive(false);
    }
}
