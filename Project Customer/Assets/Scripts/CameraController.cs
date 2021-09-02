using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 Origin;
    [SerializeField] Vector3 Difference;

    Vector3 dragStart;
    Vector3 dragCurrent;
    public Camera cam;

    float movementTime = 5;
    Vector3 newPosition;

    private void Start()
    {
        newPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        CameraZoom();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }

    private void CameraZoom()
    {
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //cam.fieldOfView--;
            transform.position = new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z + .3f);
            newPosition = cam.transform.position;
        }

        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //cam.fieldOfView++;
            transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z - .3f);
            newPosition = cam.transform.position;
        }
    }

    private void MoveCamera()
    {
        // Moving camera
        

        if (Input.GetMouseButtonDown(0))
        {
            //Origin = cam.ScreenToWorldPoint(Input.mousePosition);

            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            float entryPoint;
            
            if(plane.Raycast(ray, out entryPoint))
            {
                dragStart = ray.GetPoint(entryPoint);
            }

        }

        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            float entryPoint;

            if (plane.Raycast(ray, out entryPoint))
            {
                dragCurrent = ray.GetPoint(entryPoint);

                newPosition = transform.position + dragStart - dragCurrent;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            newPosition = cam.transform.position;
        }


    }
}
