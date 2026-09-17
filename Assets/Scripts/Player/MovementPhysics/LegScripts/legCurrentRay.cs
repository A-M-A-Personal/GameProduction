using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class legCurrentRay : MonoBehaviour
{
    public RaycastHit currentFloorLocation;
    [SerializeField]private Transform newLocation, bodyLocation;
    private bool isMoving = false;
    private float speed = 50f;
    private Vector3 end;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (((Vector3.Distance(newLocation.position, transform.position)) > 5f) & !isMoving)
        {
            isMoving = true;
            end = newLocation.position;
        }
        else 
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, end, step);
            if (Vector3.Distance(transform.position, end) < 0.001f)
            {
                isMoving = false;
            }
        }


        transform.rotation = newLocation.rotation;
        transform.Rotate(-(transform.rotation.y * 2), 0, 0);
        
        Physics.Raycast(transform.position, transform.up, out currentFloorLocation, 5f);
    }

}
