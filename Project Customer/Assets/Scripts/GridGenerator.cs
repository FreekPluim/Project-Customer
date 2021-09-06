using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject node;
    GameObject nodes;
    NodeScript script;
    int xSize = 40;
    int zSize = 40;
    int id = 0;


    void Start()
    {
        nodes = new GameObject("Nodes");
        

        for (int z = 2; z < zSize; z += 4)
        {
            for (int x = 2; x < xSize; x += 4)
            {      
                id++;
                Vector3 position = new Vector3(x - xSize/2, 0, z -zSize/2);

                GameObject Node = Instantiate(node, position, Quaternion.identity);
                script = Node.GetComponent<NodeScript>();
                Node.transform.SetParent(nodes.transform);
                Node.name = "node" + id;
                script.id = id;
            }
        }
    }
}
