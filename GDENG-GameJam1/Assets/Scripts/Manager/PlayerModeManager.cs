using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerMode
{
    Collect,
    Vacuum,
    Spawn,
    Mode4,
    Pause
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
        {
            currentMode = PlayerMode.Collect;
            EventBroadcaster.Instance.PostEvent(EventNames.PlayerMode.MOP_MODE);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentMode = PlayerMode.Vacuum;
            EventBroadcaster.Instance.PostEvent(EventNames.PlayerMode.VACUUM_MODE);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentMode = PlayerMode.Spawn;
            EventBroadcaster.Instance.PostEvent(EventNames.PlayerMode.BROOM_MODE);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentMode = PlayerMode.Mode4;
            EventBroadcaster.Instance.PostEvent(EventNames.PlayerMode.MODE4);
        }

        /// Pause Menu when called
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentMode = PlayerMode.Pause;
        }
    }
}
