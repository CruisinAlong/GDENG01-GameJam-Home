using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
}
