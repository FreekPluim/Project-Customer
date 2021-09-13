using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWindDistance : MonoBehaviour
{
    public BoxCollider trigger;

    [SerializeField] GameObject playerData;


    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Windmill"))
        {
            //Debug.Log("Found trigger on: <b>" + other.name + "</b>");
            other.GetComponent<DistanceToCity>().IsToClose(true);
        }
    }
}
