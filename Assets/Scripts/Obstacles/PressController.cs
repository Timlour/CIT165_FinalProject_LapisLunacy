using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressController : MonoBehaviour
{

    public float seconds = 2.0f;
    public float delaySeconds = 0.0f;
    public float pauseSeconds = 2.0f;
    public float distance = 2.5f;

    private Vector3 velocity = Vector3.zero;
    private float pressTimer;
    private Vector3 startPosition, endPosition, targetPosition;

    void Awake()
    {
        //Get the starting position
        startPosition = transform.position;
        // Define a ending position
        endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - distance);

        //Define the target position
        targetPosition = endPosition;

    }

    // Update is called once per frame
    void Update()
    {

        //Move the press if it is not getting delayed
        if (delaySeconds <= 0.0f)
        {
            pressTimer += Time.deltaTime;

            if (pressTimer >= seconds + pauseSeconds)
            {
                pressTimer = 0;
                togglePress();
            }

            // Smoothly move the press towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, seconds);
        }
        //If there is a delay, wait until the delay seconds have passed to move the press
        else
            delaySeconds -= Time.deltaTime;

    }

    private void togglePress()
    {
        //Invert the distance so that it reverses when it reaches the end of its movement
        distance = -distance;

        //Swap the target position based on its current value as either the starting or ending position
        if (targetPosition == startPosition)
            targetPosition = endPosition;
        else
            targetPosition = startPosition;

    }//end of togglePress
}
