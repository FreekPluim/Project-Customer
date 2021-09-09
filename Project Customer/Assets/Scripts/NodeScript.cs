using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [SerializeField] GameObject ocean;
    [SerializeField] GameObject plains;
    [SerializeField] GameObject desert;
    [SerializeField] GameObject city;
    [SerializeField] GameObject oil;
    [SerializeField] GameObject gas;
    [SerializeField] GameObject coal;


    Ray ray;
    RaycastHit hit;
    public bool available = true;

    Vector3 tilePos;
    Vector3 cityPos;
    Vector3 plantPos;

    /*    public enum NodeType{
            Ocean,
            Plains,
            Desert,
            Hills,
            Forest,
            City
        };

        public NodeType type;*/

    public int id;
    public int typeID;

    public string title;
    public int windBoost;
    public int solarBoost;

    private void Awake()
    {
        ray = new Ray(transform.localPosition, Vector3.up);
        tilePos = new Vector3(transform.localPosition.x, (transform.localPosition.y - ocean.transform.localScale.y * 0.5f), transform.localPosition.z);
        cityPos = new Vector3(transform.localPosition.x, (transform.localPosition.y + 0.01f + city.transform.localScale.y * 0.5f), transform.localPosition.z);
        plantPos = new Vector3(transform.localPosition.x, (transform.localPosition.y + oil.transform.localScale.y * 0.5f), transform.localPosition.z);
    }

    private void Update()
    {
        
        if (Physics.Raycast(ray, 1f) && available)
        {
            Debug.Log("ray hit!");
            available = false;
        }
        else if(!Physics.Raycast(ray, 1f) && !available)
        {
            available = true;
        }
    }

    public void SetNodeType(int ID)
    {
        //tile = Instantiate(plains, transform.localPosition, Quaternion.identity);
        switch (ID)
        {
            case 0:     //Ocean
                Instantiate(ocean, tilePos, Quaternion.identity);
                title = "Ocean";
                windBoost = 20;
                Debug.Log("Ocean tile spawned!");
                break;
            case 1:     //Plains
                Instantiate(plains, tilePos, Quaternion.identity);
                title = "Plains";
                Debug.Log("Plains tile spawned!");
                break;
            case 2:     //Desert
                Instantiate(desert, tilePos, Quaternion.identity);
                title = "Desert";
                solarBoost = 20;
                Debug.Log("Desert tile spawned!");
                break;
            case 3:     //Hills
                Debug.Log("Hills not yet implemented");
                break;
            case 4:     //Forest
                Debug.Log("Forest not yet implemented");
                break;
            case 5:     //City
                Instantiate(city, cityPos, Quaternion.identity);
                title = "City";
                available = false;
                Debug.Log("City spawned!");
                break;
            case 6:     //Polluting plant
                Instantiate(plains, tilePos, Quaternion.identity);
                SpawnPowerPlant();
                title = "Plains/PowerPlant";
                break;
            default:    //Type not found
                Debug.Log("404 Node type not found!");
                break;
        }
        Debug.Log("NodeType set!");
        typeID = ID;
    }

    void SpawnPowerPlant()
    {
        int type = Random.Range(0, 3);

        switch (type)
        {
            case 0:
                Instantiate(oil, transform.localPosition, Quaternion.identity);
                break;
            case 1:
                Instantiate(gas, transform.localPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(coal, transform.localPosition, coal.transform.rotation);
                break;
        }
    }
}
