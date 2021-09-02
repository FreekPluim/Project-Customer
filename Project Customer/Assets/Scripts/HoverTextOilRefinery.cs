using UnityEngine;

public class HoverTextOilRefinery : MonoBehaviour
{
    GameObject oilRefineryText;
    GameObject oilInfo;

    private void Awake()
    {
        oilRefineryText = GameObject.FindGameObjectWithTag("OilRefineryText");
        oilInfo = GameObject.FindGameObjectWithTag("OilInfo");
    }

    // Start is called before the first frame update
    void Start()
    {
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
            oilInfo.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        oilRefineryText.SetActive(false);
    }
}


