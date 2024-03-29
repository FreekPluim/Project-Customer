using UnityEngine;

public class HoverTextGasProcessingPlant : MonoBehaviour
{
    [SerializeField] GameObject gasProcessingText;
    GameObject gasInfo;

    private GameObject moneyManager;
    private float price;

    private void Awake()
    {
        gasInfo = GameObject.FindGameObjectWithTag("GasInfo");

    }

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("PlayerData");
        price = moneyManager.GetComponent<PlayerMoney>().gasPrice;

        gasProcessingText.SetActive(false);
        gasInfo.SetActive(false);

        
    }

    private void Update()
    {
        gasProcessingText.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 15, Input.mousePosition.z);
    }

    public void OnMouseOver()
    {
        gasProcessingText.SetActive(true);
        if (Input.GetButtonUp("Fire1"))
        {
            gasInfo.GetComponent<CloseInfo>().LinkObjectAndPrice(gameObject, price);
            gasInfo.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        gasProcessingText.SetActive(false);
    }
}

