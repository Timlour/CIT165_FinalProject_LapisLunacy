using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public Transform currentSpawnPoint;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        //If player collides with this object, respawn them to their spawn point
        if (other.gameObject.CompareTag("Respawn") || other.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Respawning...");
            this.transform.position = new Vector3(currentSpawnPoint.position.x, currentSpawnPoint.position.y, currentSpawnPoint.position.z);
            //Temporarily make kinematic to stop all forces so the player does not roll when respawning
            rb.isKinematic = true;
            rb.AddForce(Vector3.zero);
            rb.isKinematic = false;
        }

    }//end of OnTriggerEnter
}
