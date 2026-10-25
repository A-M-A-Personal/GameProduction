using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused = false;
    public void onPause(InputValue value)
    {
        if (value.isPressed)
            TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    
    }
}
