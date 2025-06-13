using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject optionsPanel; 
    public GameObject pausePanel;   

    public void OpenOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }
}
