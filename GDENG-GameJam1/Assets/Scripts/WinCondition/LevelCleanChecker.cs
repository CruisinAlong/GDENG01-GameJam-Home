using System;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelCleanChecker : MonoBehaviour
{
    public int totalScoreToWin { get; private set; }
    public GameObject winPanel;
    
    private void Start()
    {
        totalScoreToWin = 0;

        // Sum up all score values from cleanable objects at level start
        foreach (var m in FindObjectsByType<Movable>(FindObjectsSortMode.None))
            totalScoreToWin += m.scoreValue;

        foreach (var v in FindObjectsByType<CollectibleVacuum>(FindObjectsSortMode.None))
            totalScoreToWin += v.scoreValue;

        foreach (var mop in FindObjectsByType<Mop>(FindObjectsSortMode.None))
            totalScoreToWin += mop.scoreValue;

        foreach (var brush in FindObjectsByType<CollectibleSpawn>(FindObjectsSortMode.None))
            totalScoreToWin += brush.scoreValue * 4;

        Debug.Log($"[LevelCleanChecker] Total score to win: {totalScoreToWin}");
    }


    public void CheckWinCondition(int playerScore)
    {
        Debug.Log($"[LevelCleanChecker] Player score: {playerScore}, Needed: {totalScoreToWin}");
        if (playerScore >= totalScoreToWin)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.SFXNames.STOP_BG);
            Debug.Log("Level is fully cleaned! (Score-based)");
            if (winPanel != null)
            {
                winPanel.SetActive(true);
                SfxManager.instance.PlaySFX(EventNames.SFXNames.WIN,0.4f);
            }
            // Optionally, pause the game here
            Time.timeScale = 0f;
        }
    }
}
