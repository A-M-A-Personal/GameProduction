using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class hitScan : MonoBehaviour
{
    [SerializeField] private PlayerNoises noises;
    private LevelInputs input;
    [SerializeField] private Stats stats;
    private Vector2 mouseLocation;

    private float maximumRange = 50000f;
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        input = new LevelInputs();
        input.Enable();
    }
    private void Start()
    {
        input.clicked.Click.performed += OnMouseClick;
        input.clicked.MouseLocation.performed += MousePosition;
    }

    private void MousePosition(InputAction.CallbackContext obj)
    {
        mouseLocation = obj.ReadValue<Vector2>();
    }

    private void OnMouseClick(InputAction.CallbackContext obj)
    {
        if (Stats.charge != 0)
        {
            noises.PlayShooting();
            Stats.charge--;
            stats.chargeUsed();
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray _ray = mainCamera.ScreenPointToRay(mousePos);
            RaycastHit _raycasthit;
            if (Physics.Raycast(_ray, out _raycasthit, maximumRange))
            {
                Debug.DrawRay(_ray.origin, _ray.direction * maximumRange, Color.red, 10f);
                Debug.Log("Mouse: " + mouseLocation);
                Debug.Log("Camera location: " + mainCamera.transform.position);
                Debug.Log("Ray Direction: " + _ray.direction);
                if (_raycasthit.collider.tag == "Targetable")
                {
                    Destroy(_raycasthit.collider.gameObject);

                }
            }
        }
        else
        {
            noises.PlayOutOfAmmo();
        }
    }

    public void OnDestroy()
    {
        input.Disable();
    }
}
