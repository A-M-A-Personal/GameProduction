using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    
    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

    }
    public void SetResolution (int index)
    {
        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 3:
                Screen.SetResolution(800, 600, true);
                break;
        }
    }
}
