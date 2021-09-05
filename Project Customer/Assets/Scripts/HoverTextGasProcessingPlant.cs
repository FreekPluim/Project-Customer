using UnityEngine;

public class HoverTextGasProcessingPlant : MonoBehaviour
{
    GameObject gasProcessingText;
    GameObject gasInfo;

    private void Awake()
    {
        gasProcessingText = GameObject.FindGameObjectWithTag("GasProcessingPlantText");
        gasInfo = GameObject.FindGameObjectWithTag("GasInfo");
    }

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetButton("Fire1"))
        {
            gasInfo.GetComponent<CloseInfo>().LinkObjectAndPrice(gameObject, 9000);
            gasInfo.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        gasProcessingText.SetActive(false);
    }
}

