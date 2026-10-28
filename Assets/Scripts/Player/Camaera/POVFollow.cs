using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class POVFollow : MonoBehaviour
{
    [SerializeField] Transform Target;
    private SpiderTank moveAction;
    private Vector2 tilting;
    private float smoothTime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.SpiderTankControls.TurningFace.performed += onCameraTilt;
        moveAction.SpiderTankControls.TurningFace.canceled += onCameraStop;
    }

    private void onCameraTilt(InputAction.CallbackContext context)
    {
        tilting = Vector2.zero;
    }

    private void onCameraStop(InputAction.CallbackContext context)
    {
        tilting = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform _offestRotation = Target;
        _offestRotation.rotation = Quaternion.Euler(Target.rotation.eulerAngles.x, Target.rotation.eulerAngles.y + tilting.y, Target.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, _offestRotation.rotation, smoothTime * Time.deltaTime);

    }
}