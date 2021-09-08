using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [SerializeField] GameObject ocean;
    [SerializeField] GameObject plains;
    [SerializeField] GameObject desert;

    public bool available = true;

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

    public GameObject tileTypes;
    public GameObject tile;

    public void SetNodeType(int ID)
    {
        //tile = Instantiate(plains, transform.localPosition, Quaternion.identity);
        switch (ID)
        {
            case 0:     //Ocean
                Instantiate(ocean, transform.localPosition, Quaternion.identity);
                title = "Ocean";
                windBoost = 10;
                Debug.Log("Ocean tile spawned!");
                break;
            case 1:     //Plains
                Instantiate(plains, transform.localPosition, Quaternion.identity);
                title = "Plains";
                Debug.Log("Plains tile spawned!");
                break;
            case 2:     //Desert
                Instantiate(desert, transform.localPosition, Quaternion.identity);
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
                Debug.Log("City not yet implemented");
                break;
            default:    //Type not found
                Debug.Log("404 Node type not found!");
                break;
        }
        Debug.Log("NodeType set!");
        typeID = ID;
    }
}
