using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float actionDelay = 0.5f; // Delay in seconds before starting game or quitting

    public void StartGame()
    {
        SfxManager.instance?.PlaySFX(EventNames.SFXNames.CLICK);
        StartCoroutine(DelayedStartGame());
    }

    public void ExitGame()
    {
        SfxManager.instance?.PlaySFX(EventNames.SFXNames.CLICK);
        StartCoroutine(DelayedExitGame());
    }

    private IEnumerator DelayedStartGame()
    {
        yield return new WaitForSecondsRealtime(actionDelay);
        SceneManager.LoadScene("Kitchen");
    }

    private IEnumerator DelayedExitGame()
    {
        yield return new WaitForSecondsRealtime(actionDelay);
        Application.Quit();
    }
}
