using System.Net.NetworkInformation;
using UnityEngine;

using System.Collections;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void LoadScene(int Game)
    {
        StartCoroutine(DoSomething(2));
        

    }

    IEnumerator DoSomething(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("Level1");
    }


}

