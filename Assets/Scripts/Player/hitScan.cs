using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class hitScan : MonoBehaviour
{
    [SerializeField] private PlayerNoises noises;
    private InputAction leftMouseClick;
    [SerializeField] private Stats stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftMouseClick = new InputAction(binding: "<Mouse>/leftButton");
        leftMouseClick.performed += ctx => LeftMouseClicked();
        leftMouseClick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LeftMouseClicked()
    {
        if (Stats.charge != 0)
        {
            noises.PlayShooting();
            Stats.charge--;
            stats.chargeUsed();
            print("LeftMouseClicked");
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                Debug.DrawRay(transform.position, hit.point, Color.red, 3f);
                if (hit.collider.tag == "Targetable")
                {
                    print("Hit!");
                    Destroy(hit.collider.gameObject);

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
        leftMouseClick.Disable();
    }
}
