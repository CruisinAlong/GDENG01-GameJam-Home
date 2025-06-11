using System.Collections.Generic;
using UnityEngine;

public enum PlayerMode
{
    Collect,
    Vacuum,
    Spawn,
    Mode4 
}


public class PlayerModeManager : MonoBehaviour
{

    private HashSet<PlayerMode> unlockedModes = new HashSet<PlayerMode> { PlayerMode.Collect };
    public static PlayerModeManager Instance { get; private set; }  
    public PlayerMode currentMode = PlayerMode.Collect;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void SetUnlockedModes(List<PlayerMode> modes)
    {
        unlockedModes = new HashSet<PlayerMode>(modes);
        // Optionally, reset currentMode if it's now locked
        if (!unlockedModes.Contains(currentMode))
            if (unlockedModes.Count > 0)
            {
                foreach (var mode in unlockedModes)
                {
                    currentMode = mode;
                    break;
                }
            }
            else
            {
                currentMode = PlayerMode.Collect;
            }

    }

    public bool IsModeUnlocked(PlayerMode mode)
    {
        return unlockedModes.Contains(mode);
    }


    private void Update()
    {
        // Example: 1, 2, 3 keys to switch modes
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentMode = PlayerMode.Collect;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentMode = PlayerMode.Vacuum;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentMode = PlayerMode.Spawn;
    }
}
