using UnityEngine;

public enum PlayerMode
{
    Collect,    // Mode 1: Collectible shrink (original)
    Vacuum,     // Mode 2: Pull with left click
    Spawn       // Mode 3: Scroll to collect and spawn new objects
}

public class PlayerModeManager : MonoBehaviour
{
    public static PlayerModeManager Instance { get; private set; }
    public PlayerMode currentMode = PlayerMode.Collect;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
