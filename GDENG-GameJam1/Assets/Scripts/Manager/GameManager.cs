using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;

    public int score = 0; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        LevelCleanChecker checker = FindFirstObjectByType<LevelCleanChecker>();
        if (checker != null)
            checker.CheckWinCondition(score);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !winPanel.activeSelf)
        {
            SfxManager.instance.StopAllSFX();
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
