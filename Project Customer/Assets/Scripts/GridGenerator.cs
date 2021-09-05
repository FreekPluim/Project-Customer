using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject node;
    GameObject nodes;
    int xSize = 40;
    int zSize = 40;


    void Start()
    {
        nodes = new GameObject("Nodes");

        for (int x = 2; x < xSize; x += 4)
        {
            for(int z = 2; z < zSize; z += 4)
            {
                Vector3 position = new Vector3(x - xSize/2, 0, z -zSize/2);

                GameObject Node = Instantiate(node, position, Quaternion.identity);
                Node.transform.SetParent(nodes.transform);
            }
        }
    }
}
