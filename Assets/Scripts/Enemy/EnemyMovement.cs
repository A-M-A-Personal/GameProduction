using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navagent;
    private Transform playerTransform;
    void Start()
    {
        
        navagent = GetComponent<NavMeshAgent>();

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        { 
         playerTransform = player.transform;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
       
            navagent.SetDestination(playerTransform.position);
        }
    }
}
