using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;          
            pauseMenu.SetActive(true); 
        }
        else
        {
            Time.timeScale = 1f;          
            pauseMenu.SetActive(false); 
        }
        }
    }
