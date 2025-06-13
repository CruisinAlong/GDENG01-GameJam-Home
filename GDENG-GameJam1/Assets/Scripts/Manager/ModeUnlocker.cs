using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeUnlocker : MonoBehaviour
{
    // Assign your UI buttons for each mode in the Inspector
    public GameObject collectButton;
    public GameObject vacuumButton;
    public GameObject spawnButton;
    public GameObject mode4Button;

    private void Start()
    {
        List<PlayerMode> unlockedModes = new List<PlayerMode>();

        string scene = SceneManager.GetActiveScene().name;


        if (scene == "Kitchen")
        {
            unlockedModes.Add(PlayerMode.Collect);
            unlockedModes.Add(PlayerMode.Vacuum);
        }
        else if (scene == "Living Room")
        {
            unlockedModes.Add(PlayerMode.Collect);
            unlockedModes.Add(PlayerMode.Vacuum);
            unlockedModes.Add(PlayerMode.Spawn);
        }
        else if (scene == "Dining Room")
        {
            unlockedModes.Add(PlayerMode.Collect);
            unlockedModes.Add(PlayerMode.Vacuum);
            unlockedModes.Add(PlayerMode.Spawn);
            unlockedModes.Add(PlayerMode.Mode4);
        }
        else
        {
            // Default: only Collect mode
            unlockedModes.Add(PlayerMode.Collect);
        }

        // Lock/unlock in PlayerModeManager
        if (PlayerModeManager.Instance != null)
            PlayerModeManager.Instance.SetUnlockedModes(unlockedModes);

        // Lock/unlock in UI
        if (collectButton != null)
            collectButton.SetActive(unlockedModes.Contains(PlayerMode.Collect));
        if (vacuumButton != null)
            vacuumButton.SetActive(unlockedModes.Contains(PlayerMode.Vacuum));
        if (spawnButton != null)
            spawnButton.SetActive(unlockedModes.Contains(PlayerMode.Spawn));
        if (mode4Button != null)
            mode4Button.SetActive(unlockedModes.Contains(PlayerMode.Mode4));
    }
}
