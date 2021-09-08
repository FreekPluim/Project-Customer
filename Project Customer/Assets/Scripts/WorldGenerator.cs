using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    NodeScript nodeScript;
    GameObject[] nodes;

    List<GameObject> plainsNodes = new List<GameObject>();

    int nodeIndex = 1;
    int cityAmount;
    int generatorAmount;

    //nodeTypes holds nodeIDs for each node on the map.
    // 0 = ocean
    // 1 = Plains
    // 2 = Desert
    // 3 = Hills
    // 4 = Forest
    // 5 = City
    // 6 = power plant

    int[] nodeTypes = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 6, 1, 0,
                          0, 1, 1, 1, 6, 1, 1, 1, 1, 1, 1, 0,
                          0, 1, 1, 5, 1, 1, 1, 5, 1, 1, 1, 0,
                          0, 1, 6, 1, 1, 1, 6, 1, 1, 1, 1, 0,
                          0, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 0,
                          0, 1, 2, 2, 2, 1, 1, 1, 5, 1, 1, 0,
                          0, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 0,
                          0, 1, 1, 1, 6, 1, 1, 1, 6, 1, 1, 0,
                          0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                          0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private void Start()
    {
        if (nodes == null)
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");
        }

        cityAmount = Random.Range(2, 4);
        generatorAmount = cityAmount * 2;

        LoadNodeTypes();
        GenerateBuildings();
    }

    private void Update()
    {
        
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
        foreach (GameObject node in nodes)
        {
            nodeScript = node.GetComponent<NodeScript>();
            if (nodeScript.typeID == 1)
            {
                plainsNodes.Add(node);
            }
        }


    }

/*    void PlaceCities()
    {
        foreach(GameObject node in nodes)
        {
            nodeScript = node.GetComponent<NodeScript>();
            if(nodeScript.typeID == 1)
            {
                plainsNodes.Add(node);
            }
        }

        Debug.Log(plainsNodes.Count);

        for(int i = 0; i < 4; i++)
        {
            GameObject randomNode = plainsNodes[Random.Range(0, plainsNodes.Count)];
            randomNode.GetComponent<NodeScript>().SetNodeType(5);
        }
    }*/
}
