using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInfo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.mousePosition.x < transform.position.x)
        {
            if (Input.GetButton("Fire1"))
            { gameObject.SetActive(false); }
        }
    }

    public void OnCloseButtonPress()
    {
        gameObject.SetActive(false);
    }


}
