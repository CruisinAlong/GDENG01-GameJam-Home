using UnityEngine;
using TMPro;

public class CleanableCounter : MonoBehaviour
{
    public static CleanableCounter Instance { get; private set; }
    public TextMeshProUGUI cleanablesLeftText; // Assign in Inspector

    private int cleanablesLeft = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Count all cleanable objects at the start
        cleanablesLeft = 0;
        cleanablesLeft += Object.FindObjectsByType<Movable>(FindObjectsSortMode.None).Length;
        cleanablesLeft += Object.FindObjectsByType<CollectibleVacuum>(FindObjectsSortMode.None).Length;
        cleanablesLeft += Object.FindObjectsByType<Mop>(FindObjectsSortMode.None).Length;
        cleanablesLeft += Object.FindObjectsByType<CollectibleSpawn>(FindObjectsSortMode.None).Length * 4;
        

        Parameters cleanables = new Parameters();
        cleanables.PutExtra(EventNames.Clean_Events.PARAM_CLEANABLES_LEFT, cleanablesLeft);
        EventBroadcaster.Instance.PostEvent(EventNames.Clean_Events.NUM_CLEANABLES_LEFT, cleanables);
    }

    public void DecrementCleanable()
    {
        cleanablesLeft = Mathf.Max(0, cleanablesLeft - 1);
        Parameters cleanables = new Parameters();
        cleanables.PutExtra(EventNames.Clean_Events.PARAM_CLEANABLES_LEFT, cleanablesLeft);
        EventBroadcaster.Instance.PostEvent(EventNames.Clean_Events.NUM_CLEANABLES_LEFT, cleanables);
    }
}
