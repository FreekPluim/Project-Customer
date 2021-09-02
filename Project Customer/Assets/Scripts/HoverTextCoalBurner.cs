using UnityEngine;

public class HoverTextCoalBurner : MonoBehaviour
{
    GameObject coalBurnerText;
    GameObject coalInfo;

    private void Awake()
    {
        coalBurnerText = GameObject.FindGameObjectWithTag("CoalBurnerText");
        coalInfo = GameObject.FindGameObjectWithTag("CoalInfo");
    }

    // Start is called before the first frame update
    void Start()
    {
        coalBurnerText.SetActive(false);
        coalInfo.SetActive(false);
    }

    private void Update()
    {
        coalBurnerText.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 15, Input.mousePosition.z); ;
    }

    public void OnMouseOver()
    {
        coalBurnerText.SetActive(true);
        if (Input.GetButton("Fire1"))
        {
            coalInfo.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        coalBurnerText.SetActive(false);
    }
}
