using UnityEngine;

public class HoverTextOilRefinery : MonoBehaviour
{
    [SerializeField] GameObject oilRefineryText;
    GameObject oilInfo;

    private GameObject moneyManager;
    private float price;

    private void Awake()
    {
        oilInfo = GameObject.FindGameObjectWithTag("OilInfo");
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData");
        price = moneyManager.GetComponent<PlayerMoney>().oilPrice;

        oilRefineryText.SetActive(false);
        oilInfo.SetActive(false);
    }

    private void Update()
    {
        oilRefineryText.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 15, Input.mousePosition.z); ;
    }

    public void OnMouseOver()
    {
        oilRefineryText.SetActive(true);
        if (Input.GetButton("Fire1"))
        {
            oilInfo.GetComponent<CloseInfo>().LinkObjectAndPrice(gameObject, 8000);
            oilInfo.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        oilRefineryText.SetActive(false);
    }
}


