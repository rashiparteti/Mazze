using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        // Get the NavMeshAgent component attached to the enemy
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Attempt to find the player GameObject by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Check if the playerObject is found
        if (playerObject != null)
        {
            // Get the position of the player
            Vector3 playerPosition = playerObject.transform.position;

            // Set the destination of the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(playerPosition);
        }
    }

    // Optional: Visualize the path for debugging purposes
    void OnDrawGizmos()
    {
        if (navMeshAgent == null || navMeshAgent.path == null)
            return;

        var line = navMeshAgent.path.corners;
        if (line.Length < 2)
            return;

        Gizmos.color = Color.green;
        for (int i = 0; i < line.Length - 1; i++)
        {
            Gizmos.DrawLine(line[i], line[i + 1]);
        }
    }
}
