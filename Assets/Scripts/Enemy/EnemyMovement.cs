using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    protected float smoothTime = 5f, fallspeed = 10f;
    protected NavMeshAgent navagent;
    protected Transform playerTransform;
    [SerializeField] protected float Movespeed = 25f;
    [SerializeField] protected Transform self;
    protected Rigidbody rb;
    protected virtual void Start()
    {
        
        navagent = GetComponent<NavMeshAgent>();
        rb = self.GetComponent<Rigidbody>();
        GameObject player = GameObject.FindWithTag("NeedleTarget");

        if (player != null)
        { 
         playerTransform = player.transform;
        }


    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (playerTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Movespeed * Time.deltaTime);
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 4f))
            {
                Vector3 position = hit.point;
                Ray upRay = new Ray(position, transform.position - position);

                Vector3 upDist = upRay.GetPoint(2f);

                Vector3 Dif = upDist - transform.position;
                float secondarySmooth = Dif.magnitude / smoothTime;
                rb.linearVelocity = Dif / Mathf.Max(secondarySmooth, Time.fixedUnscaledDeltaTime);
            }
            else if (!(Physics.Raycast(transform.position, -transform.up, out RaycastHit falling, 4f)))
            {
                rb.AddForce(-transform.up * fallspeed);
            }
        }
    }
}
