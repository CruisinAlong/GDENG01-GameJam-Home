using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public string nextLevelSceneName; 

    public void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextLevelSceneName))
            SceneManager.LoadScene(nextLevelSceneName);
        else
            Debug.LogWarning("NextLevelButton: nextLevelSceneName is not set!");
    }
}
