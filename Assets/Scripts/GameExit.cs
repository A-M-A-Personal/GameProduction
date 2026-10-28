using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public void LoadScene(int Menu)
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 0f;
    }
}
