using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public bool isActiveOnStart = false;

    public float seconds = 2.0f;
    public float delaySeconds = 0.0f;

    private bool isActive;
    private float timer;

    void Awake()
    {
        isActive = isActiveOnStart;
        gameObject.GetComponent<Renderer>().enabled = isActive;
        gameObject.GetComponent<MeshCollider>().enabled = isActive;
    }

    // Update is called once per frame
    void Update()
    {
        //Toggle the laser if it is not getting delayed
        if (delaySeconds <= 0.0f)
        {
            timer += Time.deltaTime;
            if (timer >= seconds)
            {
                timer = 0;
                toggleLaser();
            }

        }
        //If there is a delay, wait until the delay seconds have passed to toggle the laser
        else
            delaySeconds -= Time.deltaTime;
    }

    private void toggleLaser()
    {
        //Toggle the laser (active or not active)
        isActive = !isActive;
        gameObject.GetComponent<Renderer>().enabled = isActive;
        gameObject.GetComponent<MeshCollider>().enabled = isActive;
    }//end of toggleLaser
}
