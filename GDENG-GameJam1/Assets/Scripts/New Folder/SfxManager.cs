using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager instance;
    
    [Header("SFX Prefab")]
    public AudioSource audioSourcePrefab;
    
    [Header("SFX Settings")]
    public int audioPoolSize = 11;
    
    [Header("SFXClips")]
    public List<AudioClip> sfxClips;
    
    
    
    private Queue<AudioSource> audioPool;
    private List<SFXInstance> activePool;
    
    private Dictionary<string, AudioClip> sfxClipLookup;

    public List<string> audioNames;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudios();
            InitializePool();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeAudios()
    {
        sfxClipLookup = new Dictionary<string, AudioClip>();

        for(int i = 0; i < audioNames.Count; i++)
        {
            if(i <  sfxClips.Count)
                sfxClipLookup[audioNames[i]] = sfxClips[i];
        }
    }
    
    void InitializePool()
    {
        audioPool = new Queue<AudioSource>();
        activePool = new List<SFXInstance>();

        for (int i = 0; i < audioPoolSize; i++)
        {
            AudioSource source = Instantiate(audioSourcePrefab, transform);
            source.playOnAwake = false;
            source.gameObject.SetActive(false);
            audioPool.Enqueue(source);
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach (var audioSource in audioPool.Where(audioSource => !audioSource.isPlaying))
        {
            return audioSource;
        }
        
        return null;
    }
    
    bool IsSFXAlreadyPlaying(string name)
    {
        foreach (SFXInstance instance in activePool)
        {
            if (instance.name == name && instance.audioSource.isPlaying)
            {
                return true;
            }
        }
        return false;
    }
    public void PlaySFX(string name, float volume = 1.0f)
    {
        if (IsSFXAlreadyPlaying(name))
        {
            return;
        }
        
        if (sfxClipLookup.ContainsKey(name))
        {
            
            AudioSource audioSource = GetAvailableAudioSource();
            
            audioSource.clip = sfxClipLookup[name];
            audioSource.volume = volume;
            audioSource.loop = false;
            audioSource.gameObject.SetActive(true);
            SFXInstance instance = new SFXInstance(name, audioSource);
            activePool.Add(instance);


            StartCoroutine(DeactivateAudio(audioSource, audioSource.clip.length,name));
         
        }
        else
        {
            Debug.Log($"[SFXManager] SFX clip not found: {name}");
        }
    }

    private IEnumerator DeactivateAudio(AudioSource audioSource, float clipLength, string name)
    {
        audioSource.Play();
        yield return new WaitForSeconds(clipLength);
        StopSFX(name);
        audioSource.gameObject.SetActive(false);
    }

    public void PlayLoopingSFX(string name, float volume = 1.0f)
    {
        if (IsSFXAlreadyPlaying(name))
        {
            return;
        }
        
        if (sfxClipLookup.ContainsKey(name))
        {
            AudioSource audioSource = GetAvailableAudioSource();
            
            audioSource.clip = sfxClipLookup[name];
            audioSource.volume = volume;
            audioSource.loop = true;
            audioSource.gameObject.SetActive(true);
            audioSource.Play();
            SFXInstance instance = new SFXInstance(name, audioSource);
            activePool.Add(instance);
            
            
        }
        else
        {
            Debug.Log($"[SFXManager] SFX clip not found: {name}");
        }
    }
    public void StopSFX(string name)
    {
        for (int i = activePool.Count - 1; i >= 0; i--)
        {
            if (activePool[i].name == name)
            {
                AudioSource source = activePool[i].audioSource;
                source.Stop();
                source.gameObject.SetActive(false);
                activePool.RemoveAt(i);
            }
        }
    }
}