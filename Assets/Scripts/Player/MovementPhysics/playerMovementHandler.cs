using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovementHandler : MonoBehaviour
{
    //Various numbers
    private float spiderMovespeedMultiplier = 200f, spiderTurnSpeedMultiplier = 500f, smoothTime = 5f, fallspeed = 10f;
    //Physic thingies
    private bool crash;
    [SerializeField] private Transform GameObject;
    private Rigidbody rb;
    //Movement and imput stuff    
    private Vector2 turning;
    private Vector3 spiderInfo;
    private quaternion targetRot;
    private SpiderTank moveAction, turn, jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initiate Movement
        spiderInfo = Vector3.zero;
        moveAction = new SpiderTank();
        moveAction.Enable();
        moveAction.SpiderTankControls.Movement.performed += onSpiderMove;
        moveAction.SpiderTankControls.Movement.canceled += onSpiderStop;
        moveAction.SpiderTankControls.TurningFace.performed += onSpiderTurn;
        moveAction.SpiderTankControls.TurningFace.canceled += onSpiderStraight;
        rb = GameObject.GetComponent<Rigidbody>();
    }

    private void onSpiderStraight(InputAction.CallbackContext context)
    {
        turning = Vector2.zero;
    }

    private void onSpiderTurn(InputAction.CallbackContext context)
    {
        turning = context.ReadValue<Vector2>();
    }

    private void onSpiderStop(InputAction.CallbackContext context)
    {
        //Sets Vector3 to zero to stop movement
        spiderInfo = Vector3.zero;
    }

    private void onSpiderMove(InputAction.CallbackContext context)
    {
        //Set Vector3 to relevent direction based on input
        spiderInfo = context.ReadValue<Vector3>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        crash = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        crash = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Plane Level Movement
        if ((spiderInfo.x > 0))
        {
            rb.AddForce(transform.right * spiderMovespeedMultiplier);
        }
        else if ((spiderInfo.x < 0))
        {
            rb.AddForce(-transform.right * spiderMovespeedMultiplier);
        }
        if ((spiderInfo.z > 0))
        {
            rb.AddForce(transform.forward * spiderMovespeedMultiplier);
        }
        else if ((spiderInfo.z < 0))
        {
            rb.AddForce(-transform.forward * spiderMovespeedMultiplier);
        }

        if (!(turning.x == 0))
        {
            Debug.Log(turning.ToString());
            rb.AddTorque(Vector3.up * spiderTurnSpeedMultiplier * turning.x * Time.deltaTime);
        }

        //Floor distance setter
        if (!crash)
        {
            targetRot = Quaternion.Euler(0, GameObject.transform.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, smoothTime * Time.deltaTime);
        }


        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 4f))
        {
            if (spiderTurnSpeedMultiplier == 0f) { spiderMovespeedMultiplier = 200f; spiderTurnSpeedMultiplier = 200f; }
            Vector3 position = hit.point;
            //shoot a raycast up from that position towards the object
            Ray upRay = new Ray(position, transform.position - position);

            //get a point (vector3) in that ray 1 and a half units from its origin
            Vector3 upDist = upRay.GetPoint(2f);

            //smoothly go to its position(WITH PHYSICS DAMMIT! WE HAVE AN RB FOR A REASON)
            Vector3 Dif = upDist - transform.position;
            float secondarySmooth = Dif.magnitude / smoothTime;
            rb.linearVelocity = Dif / Mathf.Max(secondarySmooth, Time.fixedUnscaledDeltaTime);
        }
        else if (!(Physics.Raycast(transform.position, -transform.up, out RaycastHit falling, 4f)))
        {
            //For when spider is falling or failsafe to prevent floating if body is flipped too much
            spiderTurnSpeedMultiplier = 0f;
            spiderMovespeedMultiplier = 0f;
            rb.AddForce(-transform.up * fallspeed);
        }
        else 
        {
            print("You're absolutely F***ed");
        }

    }

}
