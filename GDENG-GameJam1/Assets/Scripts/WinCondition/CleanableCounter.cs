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

        UpdateUI();
    }

    public void DecrementCleanable()
    {
        cleanablesLeft = Mathf.Max(0, cleanablesLeft - 1);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (cleanablesLeftText != null)
            cleanablesLeftText.text = $"To Clean: {cleanablesLeft}";
    }
}
