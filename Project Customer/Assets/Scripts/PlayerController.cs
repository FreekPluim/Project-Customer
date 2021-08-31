using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    [SerializeField] Rigidbody rb;

    private void Start()
    {
        rb = FindObjectOfType<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //GetAxis("Horizontal / Vertical") are unity implemented to take the WASD keys without having to make seperate functions.
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Set a vector 3 in the direction where i want to move.
        Vector3 move = transform.right * x + transform.forward * z;
        move.Normalize();

        rb.velocity = move * speed;
    }
}
