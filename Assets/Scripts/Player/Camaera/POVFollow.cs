using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class POVFollow : MonoBehaviour
{
    [SerializeField] Transform Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0f, 4f, -4f);
        transform.position = Target.position + offset;

    }
}