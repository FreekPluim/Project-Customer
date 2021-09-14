using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] GameObject previewBuilding;
    public GameObject building;
    [SerializeField] Material previewRed;
    [SerializeField] Material previewGreen;
    [SerializeField] Camera cam;

    [SerializeField] GameObject nodeStatUI;
    [SerializeField] Text title;
    [SerializeField] Text productionBoost;
    [SerializeField] OpenSettings settings;

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
    public bool isBuilding = false;
    public bool previewPlaced = true;

    bool placingSolar = false;
    bool placingWind = false;

    AudioManager audioManager;

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

        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if(closestNode != null)
        {
            node = closestNode;
        }

        FindClosestNode();
        BuildMode();
        DisplayNodeStats();
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


        if (!settings.settingsOpen)
        {
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
    }
    
    void BuildMode()
    {
        if (!settings.settingsOpen)
        {
            if (!previewPlaced)
            {
                preview = Instantiate(previewBuilding, Vector3.zero, Quaternion.identity);
                previewRenderer = preview.GetComponent<Renderer>();
                previewPlaced = true;
            }

            if (isBuilding)
            {
                if (preview != null)
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


            if (isBuilding && Input.GetMouseButtonDown(0))
            {
                if (nodeScript.available)
                {
                    Instantiate(building, new Vector3(closestNode.transform.localPosition.x, closestNode.transform.localPosition.y + 0.01f, closestNode.transform.localPosition.z), building.transform.rotation);
                    Destroy(preview);
                    if(audioManager != null) audioManager.Play("Building");
                    //nodeScript.available = false;

                    isBuilding = false;
                }
                else
                {
                    Debug.Log("No space!");
                }
            }
        }
    }

    void DisplayNodeStats()
    {
        if (isBuilding)
        {
            nodeStatUI.SetActive(true);
            title.text = nodeScript.title;
            if (placingSolar)
            {
                productionBoost.text = "Solar boost: " + nodeScript.solarBoost;
            }
            if (placingWind)
            {
                productionBoost.text = "Wind boost: " + nodeScript.windBoost;
            }
        }
        else
        {
            nodeStatUI.SetActive(false);
        }
    }
}
