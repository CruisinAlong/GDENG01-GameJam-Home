using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SfxManager.instance.PlaySFX(EventNames.SFXNames.CLICK);
        SceneManager.LoadScene("Kitchen");
    }

    public void ExitGame()
    {
        SfxManager.instance.PlaySFX(EventNames.SFXNames.CLICK);
        Application.Quit();
    }
}
