using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    NodeScript nodeScript;
    GameObject[] nodes;


    int nodeIndex = 1;

    //nodeTypes holds nodeIDs for each node on the map.
    // 0 = ocean
    // 1 = Plains
    // 2 = Desert
    // 3 = Hills
    // 4 = Forest
    // 5 = City

    int[] nodeTypes = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 2, 2, 2, 2, 2, 1, 1, 1, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 1, 1, 2, 2, 2, 2, 1, 1, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private void Start()
    {
        if (nodes == null)
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");
        }

        LoadNodeTypes();
    }

    void LoadNodeTypes()
    {
        if (nodes.Length != 0)
        {
            foreach (GameObject node in nodes)
            {
                nodeScript = node.GetComponent<NodeScript>();
                if (nodeScript.id == nodeIndex)
                {
                    //nodeScript.nodeID = nodeTypes[nodeIndex];
                    nodeScript.SetNodeType(nodeTypes[nodeIndex]);
                    nodeIndex++;
                }
            }
        }
        else
        {
            Debug.Log("WorldGenerator node list is empty!");
        }
    }

    void GenerateBuildings()
    {

    }
}
