using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCreator : MonoBehaviour
{

    public GameObject player;
    public Transform currentSpawnPoint;

    private PlayerController controller;

    void Awake()
    {
        controller = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {

        //If player collides with this object, set a new spawn point
        if (other.gameObject.CompareTag("Player"))
        {
            controller.currentSpawnPoint = currentSpawnPoint;
            Debug.Log("Checkpoint Set!");
        }

    }//end of OnTriggerEnter

}
