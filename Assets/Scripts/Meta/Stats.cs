using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public static int health = 3, needleHealth = 10, charge = 3;
    private bool charging = false;

    void Start()
    {
        health = 3;
        needleHealth = 10;
        charge = 3;
        charging = false;
    }

    private void Update()
    {
        if (health == 0 || needleHealth ==0)
        {
            SceneManager.LoadScene("Menu");
        }

    }

    public void chargeUsed()
    {
        if (!charging) { charging = true; StartCoroutine(startCharge());}
    }
    IEnumerator startCharge()
    {
        if (health == 0) {yield break;}
        while (charging)
        {
            yield return null;
            if (charge != 3)
            {
                if ( charge < 0 || charge > 3)
                {
                    charge = 3;
                    charging = false;
                    yield break;
                }
                yield return new WaitForSeconds(5f);
                charge++;
                if(charge == 3) {charging =  false; yield break;}
            }
        }
    }
}
