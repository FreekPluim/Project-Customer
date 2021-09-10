using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject node;
    GameObject nodes;
    NodeScript script;

    int xSize = 48;
    int zSize = 48;
    int id = 0;

    private void Awake()
    {
        nodes = new GameObject("Nodes");


        for (int z = 2; z < zSize; z += 4)
        {
            for (int x = 2; x < xSize; x += 4)
            {
                id++;
                Vector3 position = new Vector3(x - xSize / 2, -0.01f, z - zSize / 2);

                GameObject Node = Instantiate(node, position, Quaternion.identity);
                script = Node.GetComponent<NodeScript>();
                Node.transform.SetParent(nodes.transform);
                Node.name = "node" + id;
                script.id = id;
            }
        }
    }

    void Start()
    {

    }
}
