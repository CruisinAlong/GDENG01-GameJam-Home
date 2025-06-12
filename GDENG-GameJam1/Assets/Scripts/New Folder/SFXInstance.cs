using UnityEngine;

public class SFXInstance
{
    public string name;
    public AudioSource audioSource;

    public SFXInstance(string name, AudioSource audioSource)
    {
        this.name = name;
        this.audioSource = audioSource;
    }
}