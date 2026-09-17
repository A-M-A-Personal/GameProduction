using UnityEngine;

public class Forwardtest : MonoBehaviour
{
    [SerializeField] private Transform GameObject;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * 0.5f);
    }
}
