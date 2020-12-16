using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public Transform currentSpawnPoint;
    public float fallDamageVelocity = -7.0f;

    private Rigidbody rb;

    private bool isGrounded;

    private float movementX;
    private float movementY;
    private float maxYVelocity;

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
        //Debug.Log("Is Grounded: " + isGrounded + " | Y Velocity: " + rb.velocity.y + " | Max Velocity: " + maxYVelocity);
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        //If the player is grounded
        if (isGrounded)
        {
            //If the maximum velocity ever hits or goes past the maximum fall damage velocity, take damage
            if (maxYVelocity <= fallDamageVelocity)
            {
                TakeFallDamage();
                maxYVelocity = 0;
            }
        }
        //If the player is not grounded
        else
        {
            //If the player's y velocity is less than the current maxYVelocity, changing the maxYVelocity
            if(rb.velocity.y < maxYVelocity)
            {
                maxYVelocity = rb.velocity.y;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //If the player is colliding with the ground and their y velocity is greater than -1.5, they are grounded
        if (collision.gameObject.CompareTag("Ground") && rb.velocity.y > -1.5)
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //If the player stops colliding with the ground, they are falling
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
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

    private void TakeFallDamage()
    {
        Debug.Log("Respawning...");
        this.transform.position = new Vector3(currentSpawnPoint.position.x, currentSpawnPoint.position.y, currentSpawnPoint.position.z);
        //Temporarily make kinematic to stop all forces so the player does not roll when respawning
        rb.isKinematic = true;
        rb.AddForce(Vector3.zero);
        rb.isKinematic = false;
    }//end of TakeFallDamage
}
