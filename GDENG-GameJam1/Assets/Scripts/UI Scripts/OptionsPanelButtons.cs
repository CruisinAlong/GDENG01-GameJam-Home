using UnityEngine;

public class OptionsPanelButtons : MonoBehaviour
{
    public GameObject optionsPanel; 
    public GameObject pausePanel;   

    public void SetFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Screen.fullScreen = true;
    }

    public void SetWindowed()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.fullScreen = false;
    }

    public void ReturnToPauseMenu()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }
}
