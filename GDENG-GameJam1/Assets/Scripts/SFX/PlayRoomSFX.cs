using System.Collections;
using UnityEngine;

public class PlayRoomSFX : MonoBehaviour
{
    public float minDelay = 5f;  // Minimum seconds between SFX
    public float maxDelay = 15f; // Maximum seconds between SFX

    // Use the three BG_PLAYING audios
    private readonly string[] sfxNames = new string[]
    {
        EventNames.SFXNames.BG_PLAYING,
        EventNames.SFXNames.BG_PLAYING2,
        EventNames.SFXNames.BG_PLAYING3
    };

    private Coroutine sfxCoroutine;

    void Start()
    {
        if (sfxCoroutine != null)
            StopCoroutine(sfxCoroutine);
        sfxCoroutine = StartCoroutine(PlayRandomSFXLoop());
    }

    private void OnEnable()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.SFXNames.STOP_BG, StopBG);
    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.SFXNames.STOP_BG);
        if (sfxCoroutine != null)
            StopCoroutine(sfxCoroutine);
    }

    private void StopBG()
    {
        Debug.Log("Stop BG");
        if (sfxCoroutine != null)
            StopCoroutine(sfxCoroutine);
        foreach (var sfx in sfxNames)
            SfxManager.instance.StopSFX(sfx);
    }

    private IEnumerator PlayRandomSFXLoop()
    {
        // Play one immediately on start
        yield return PlayRandomSFX();

        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            yield return PlayRandomSFX();
        }
    }

    private IEnumerator PlayRandomSFX()
    {
        int idx = Random.Range(0, sfxNames.Length);
        string sfxName = sfxNames[idx];

        SfxManager.instance.PlaySFX(sfxName, 0.6f);


        AudioClip clip = SfxManager.instance.GetClip(sfxName);
        float clipLength = (clip != null) ? clip.length : 10f; 

        yield return new WaitForSeconds(clipLength);
    }
}
