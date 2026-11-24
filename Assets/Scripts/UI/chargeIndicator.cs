
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class chargeIndicator : MonoBehaviour
{
    [SerializeField] private GameObject charge1, charge2, charge3;
    private Light light;

    void Start()
    {

    }

    void Update()
    {
        if (Stats.charge == 3)
        {
            charge1.GetComponent<Renderer>().material.color = new Color(0f, 0.04705882f, 0.7490196f, 1f);
            charge1.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0.04705882f, 0.7490196f, 1f));
            charge2.GetComponent<Renderer>().material.color = new Color(0f, 0.04705882f, 0.7490196f, 1f);
            charge2.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0.04705882f, 0.7490196f, 1f));
            charge3.GetComponent<Renderer>().material.color = new Color(0f, 0.04705882f, 0.7490196f, 1f);
            charge3.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0.04705882f, 0.7490196f, 1f));

        }
        else if (Stats.charge == 2)
        {
            charge1.GetComponent<Renderer>().material.color = new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f);
            charge1.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f));
            charge2.GetComponent<Renderer>().material.color = new Color(0f, 0.04705882f, 0.7490196f, 1f);
            charge2.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0.04705882f, 0.7490196f, 1f));
            charge3.GetComponent<Renderer>().material.color = new Color(0f, 0.04705882f, 0.7490196f, 1f);
            charge3.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0.04705882f, 0.7490196f, 1f));

        }
        else if (Stats.charge == 1)
        {
            charge1.GetComponent<Renderer>().material.color = new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f);
            charge1.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f));
            charge2.GetComponent<Renderer>().material.color = new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f);
            charge2.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f));
            charge3.GetComponent<Renderer>().material.color = new Color(0f, 0.04705882f, 0.7490196f, 1f);
            charge3.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0.04705882f, 0.7490196f, 1f));

        }
        else if (Stats.charge == 0)
        {
            charge1.GetComponent<Renderer>().material.color = new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f);
            charge1.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f));
            charge2.GetComponent<Renderer>().material.color = new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f);
            charge2.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f));
            charge3.GetComponent<Renderer>().material.color = new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f);
            charge3.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.9058824f, 0.8863668f, 0.003921588f, 1f));

        }
    }
}
