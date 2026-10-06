using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navagent;
    private Transform playerTransform;
    public float Movespeed = 25f;
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

            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Movespeed * Time.deltaTime);
        }
    }
}
