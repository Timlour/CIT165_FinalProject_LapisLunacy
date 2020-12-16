using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserController : MonoBehaviour
{

    public Rigidbody playerRigidbody;

    public float pushForce = 3.0f;

    //Time between patrol destinations
    public float patrolTime = 15f;

    //Distance where the NPC will seek the player
    public float detectionRange = 10f;

    //Waypoints that define the control area, like nodes
    public Transform[] waypoints;

    int index;
    float agentSpeed;
    Transform player;
    Rigidbody rb;
    NavMeshAgent agent;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
            agentSpeed = agent.speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0, waypoints.Length);

        //Calls the Tick method every 0.5 seconds
        InvokeRepeating("Tick", 0, 0.5f);

        if (waypoints.Length > 0)
        {
            //runs the Patrol method every 15 seconds by default
            InvokeRepeating("Patrol", 0, patrolTime);
        }
    }

    void Update()
    {

    }

    void Patrol()
    {
        //In-line ternary method: if the index reached the end of the array, set to 0, if not, at 1 to index
        index = index == waypoints.Length - 1 ? 0 : index + 1;
    }//end of Patrol

    void Tick()
    {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2;

        if (player != null && Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            agent.destination = player.position;
            agent.speed = agentSpeed;
        }

    }//end of Tick

    private void OnCollisionEnter(Collision collision)
    {
        //If the enemy collides with the player, push them backwards
        if (collision.gameObject.CompareTag("Player"))
        {
            //Push the player depending on the current velocity
            Vector3 push;
            if(rb.velocity.x > rb.velocity.z)
            {
                push = new Vector3(pushForce, 0.0f, 0.0f);
            }
            else
            {
                push = new Vector3(0.0f, 0.0f, pushForce);
            }

            //Push player
            playerRigidbody.AddForce(push);
        }
    }//end of OnCollisionEnter

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}
