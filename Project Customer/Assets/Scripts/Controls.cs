using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] GameObject previewBuilding;
    [SerializeField] GameObject building;
    [SerializeField] Material previewRed;
    [SerializeField] Material previewGreen;
    [SerializeField] Camera cam;

    GameObject node;
    GameObject[] nodes;
    GameObject preview;
    GameObject closestNode;
    Renderer previewRenderer;

    NodeScript nodeScript;

    Vector3 mousePos;
    Vector3 buildingPos;
    List<Vector3> nodesPos = new List<Vector3>();

    float dist;
    bool isBuilding = false;
    bool previewPlaced = true;

    private void Start()
    {
        if (nodes == null)
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");
        }

        foreach (GameObject node in nodes)
        {
            nodesPos.Add(node.transform.position);
        }

        mousePos = Vector3.zero;
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
            mousePos = hit.point;
            //Debug.Log(hit.point);
        }

        if (nodesPos.Count != 0)
        {
            foreach (GameObject node in nodes)
            {
                float x = Mathf.Pow(node.transform.localPosition.x - mousePos.x, 2);
                float y = 0; //Mathf.Pow(mousePos.y - nodesPos[i].y, 2);
                float z = Mathf.Pow(node.transform.localPosition.z - mousePos.z, 2);
                dist = Mathf.Sqrt((x + 6) + y + (z + 4));

                if (dist < 4)
                {
                    closestNode = node;
                    if (closestNode != null)
                    {
                        nodeScript = closestNode.GetComponent<NodeScript>();
                    }
                }
            }
            //Debug.Log("Node: " + closestNode);
        }
        else
        {
            Debug.Log("Controlscript node list is empty!");
        }
    }
    
    void BuildMode()
    {       
        if (Input.GetKeyDown(KeyCode.B) && !isBuilding)
        {
            previewPlaced = false;
            isBuilding = true;
        }

        if (!previewPlaced)
        {
            preview = Instantiate(previewBuilding, Vector3.zero, Quaternion.identity);
            previewRenderer = preview.GetComponent<Renderer>();
            previewPlaced = true;
        }

        if (isBuilding)
        {
            if(preview != null)
            {
                preview.transform.localPosition = new Vector3(closestNode.transform.localPosition.x, closestNode.transform.localPosition.y + preview.transform.localScale.y * 0.5f, closestNode.transform.localPosition.z);
            }

            if (nodeScript.available)
            {
                previewRenderer.material = previewGreen;
            }
            if (!nodeScript.available)
            {
                previewRenderer.material = previewRed;
            }
        }

        if(isBuilding && Input.GetMouseButtonDown(0))
        {
            if (nodeScript.available)
            {
                Instantiate(building, new Vector3(closestNode.transform.localPosition.x, closestNode.transform.localPosition.y + building.transform.localScale.y * 0.5f, closestNode.transform.localPosition.z), Quaternion.identity);
                Destroy(preview);
                nodeScript.available = false;

                isBuilding = false;
            }
            else
            {
                Debug.Log("No space!");
            }
        }
    }
}
