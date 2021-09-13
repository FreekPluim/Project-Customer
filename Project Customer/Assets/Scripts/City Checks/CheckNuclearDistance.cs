using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNuclearDistance : MonoBehaviour
{
    [SerializeField] BoxCollider trigger;
    [SerializeField] GameObject playerData;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Found power plant with tag: <b> " + other.tag + "</b>");
        //Debug.Log("Found trigger on: <b>" + other.name + "</b>");
        if (other.CompareTag("NuclearPowerPlant"))
        {
            //Debug.Log("Found power plant");
            other.GetComponent<DistanceToCity>().IsToClose(true);
        }
    }
}
