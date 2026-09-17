using UnityEngine;

public class legTargetRay : MonoBehaviour
{
    public RaycastHit currentFloorLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, -transform.up, out currentFloorLocation, 5f);
    }
}
