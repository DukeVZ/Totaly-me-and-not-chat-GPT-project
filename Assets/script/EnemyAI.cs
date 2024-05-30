using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float stoppingDistance = 1.0f; // Distance at which the enemy stops moving towards the player
    public float aggroRange = 10.0f; // Range within which the enemy will start chasing the player
    public float roamRadius = 20.0f; // Radius within which the enemy will roam
    public float roamDelay = 3.0f; // Delay between roaming to new points

    private NavMeshAgent agent;
    private bool isAggroed = false;
    private float roamTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
        roamTimer = roamDelay;

        // Add a debug message to confirm the script is starting correctly
        Debug.Log("Enemy AI Initialized.");
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= aggroRange)
        {
            isAggroed = true;
            agent.SetDestination(player.position);
        }
        else
        {
            isAggroed = false;
        }

        if (!isAggroed)
        {
            Roam();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.transform == player)
        {
            TagPlayer();
        }
    }

    private void TagPlayer()
    {
        // Implement the logic for when the enemy tags the player
        Debug.Log("Player Tagged!");
        // Add additional functionality such as reducing the player's health or triggering a game over
        PlayerDeath playerDeath = player.GetComponent<PlayerDeath>();
        if (playerDeath != null)
        {
            playerDeath.Die();
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.transform == player)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= aggroRange)
            {
                isAggroed = true;
            }
            else
            {
                isAggroed = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.transform == player)
        {
            isAggroed = false;
        }
    }

    void Roam()
    {
        roamTimer += Time.deltaTime;

        if (roamTimer >= roamDelay)
        {
            Vector3 newRoamPosition = GetRandomRoamPosition();
            agent.SetDestination(newRoamPosition);
            roamTimer = 0f;
        }
    }

    Vector3 GetRandomRoamPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        return hit.position;
    }
}
