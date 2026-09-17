using UnityEngine;

public class legTargetMover : MonoBehaviour
{
    [SerializeField] private Transform legTarget;
    public float legAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition -= new Vector3(0, 1, 1);
        legAngle = -90f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(legTarget.position);
        transform.Rotate(legAngle, 180f, 0f);
    }
}
