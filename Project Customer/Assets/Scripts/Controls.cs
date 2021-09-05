using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] GameObject previewBuilding;
    [SerializeField] GameObject building;
    [SerializeField] Camera cam;

    GameObject node;
    GameObject[] nodes;
    GameObject preview;
    GameObject closestNode;
    NodeScript nodeScript;
    List<Vector3> nodesPos = new List<Vector3>();

    float dist;
    bool isBuilding = false;
    bool buildingPlaced = true;

    private void Start()
    {
        if(nodes == null)
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");
        }

        foreach(GameObject node in nodes)
        {
            nodesPos.Add(node.transform.position);
        }
    }

    void Update()
    {
        if(closestNode != null)
        {
            node = closestNode;
        }

        FindClosestNode();
        BuildMode();
    }

    void FindClosestNode()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.point);
            if(nodesPos.Count != 0)
            {
                for (int i = 0; i < nodesPos.Count; i++)
                {
                    float x = Mathf.Pow(nodesPos[i].x - hit.point.x, 2);
                    float y = 0; //Mathf.Pow(hit.point.y - nodesPos[i].y, 2);
                    float z = Mathf.Pow(nodesPos[i].z - hit.point.z, 2);
                    dist = Mathf.Sqrt((x + 6) + y + (z + 4));

                    if (dist < 4)
                    {
                        closestNode.transform.position = nodesPos[i];
                        nodeScript = closestNode.GetComponent<NodeScript>();
                    }
                }
                //Debug.Log("Node: " + closestNode);
            }
            else
            {
                Debug.Log("List empty!");
            }
        }
    }
    
    void BuildMode()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildingPlaced = false;
            isBuilding = true;
        }

        if (!buildingPlaced)
        {
            preview = Instantiate(previewBuilding, Vector3.zero, Quaternion.identity);
            buildingPlaced = true;
        }

        if (isBuilding)
        {
            preview.transform.localPosition = closestNode.transform.position;
        }

        if(isBuilding && Input.GetMouseButtonDown(0))
        {
            if (nodeScript.available)
            {
                Instantiate(building, closestNode.transform.position, Quaternion.identity);
                nodeScript.available = false;
                Destroy(preview);
            }
            else
            {
                Debug.Log("No space!");
            }

            isBuilding = false;
        }
    }
}
