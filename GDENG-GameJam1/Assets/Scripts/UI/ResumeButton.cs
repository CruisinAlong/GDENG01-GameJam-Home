using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    public void Resume()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
