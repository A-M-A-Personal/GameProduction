using UnityEngine;
using UnityEngine.AI;

public class agent : MonoBehaviour
{
    private NavMeshAgent agent1;
    [SerializeField]private Transform target;
    // Update is called once per frame
    void Update()
    {
        agent1.SetDestination(target.position);
    }
}
