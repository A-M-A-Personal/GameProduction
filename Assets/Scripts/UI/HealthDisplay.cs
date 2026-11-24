using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private GameObject lightObject;
    private Light light;

    void Start()
    {
        light = GetComponent<Light>();

    }

    void Update()
    {
        if (Stats.health == 3) light.color = new Color(0f, 0.04705882f, 0.7490196f, 1f);
        if (Stats.health == 2) light.color = new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f);
        if (Stats.health == 1) light.color = new Color(0.9058824f, 0.01285776f, 0.003921588f, 1f);
    }
}
