using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [SerializeField] GameObject Ocean;
    [SerializeField] GameObject Plains;
    [SerializeField] GameObject Desert;

    public bool available = true;


    public enum NodeType{
        Ocean,
        Plains,
        Desert,
        Hills,
        Forest,
        City
    };

    public NodeType type;

    public int id;
    public int nodeID;

    public void SetNodeType(int ID)
    {
        switch (ID)
        {
            case 0:     //Ocean
                //type = NodeType.Ocean;
                Instantiate(Ocean, transform.localPosition, Quaternion.identity);
                Debug.Log("Ocean tile spawned!");
                break;
            case 1:     //Plains
                //type = NodeType.Plains;
                Instantiate(Plains, transform.localPosition, Quaternion.identity);
                Debug.Log("Plains tile spawned!");
                break;
            case 2:     //Desert
                //type = NodeType.Desert;
                Instantiate(Desert, transform.localPosition, Quaternion.identity);
                Debug.Log("Desert tile spawned!");
                break;
            case 3:     //Hills
                //type = NodeType.Hills;
                Debug.Log("Hills not yet implemented");
                break;
            case 4:     //Forest
                //type = NodeType.Forest;
                Debug.Log("Forest not yet implemented");
                break;
            case 5:     //City
                //type = NodeType.City;
                Debug.Log("City not yet implemented");
                break;
            default:    //Type not found
                //type = NodeType.Ocean;
                Debug.Log("404 Node type not found!");
                break;
        }
        Debug.Log("NodeType set!");
    }
}
