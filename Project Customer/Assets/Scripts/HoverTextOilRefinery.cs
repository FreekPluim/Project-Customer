using UnityEngine;

public class HoverTextOilRefinery : MonoBehaviour
{
    [SerializeField] GameObject oilRefineryText;
    GameObject oilInfo;

    private GameObject moneyManager;
    private float price;
    PlayerPopularity popularity;

    private void Awake()
    {
        oilInfo = GameObject.FindGameObjectWithTag("OilInfo");
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData");
        price = moneyManager.GetComponent<PlayerMoney>().oilPrice;

        popularity = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerPopularity>();

        oilRefineryText.SetActive(false);
        if(oilInfo != null)
        {
            oilInfo.SetActive(false);
        }
    }

    private void Update()
    {
        oilRefineryText.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 15, Input.mousePosition.z); ;
    }

    public void OnMouseOver()
    {
        oilRefineryText.SetActive(true);
        if (popularity.tutorialOver)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                oilInfo.GetComponent<CloseInfo>().LinkObjectAndPrice(gameObject, price);
                oilInfo.SetActive(true);
            }
        }
    }

    private void OnMouseExit()
    {
        oilRefineryText.SetActive(false);
    }
}


