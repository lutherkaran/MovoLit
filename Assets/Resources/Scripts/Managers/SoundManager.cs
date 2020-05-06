using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour, IManagable
{
   
    #region Singleton
    private static SoundManager Instance;
    private SoundManager() { }
    public static SoundManager instance { get { return Instance ?? (Instance = new SoundManager()); } }
    public bool isPlaying = true;
    #endregion

     GameObject go;
    [SerializeField]
    private AudioClip[] resourceAudioClips;
    private readonly Dictionary<string,AudioClip> audioDict = new Dictionary<string,AudioClip>();

    public void Initialize()
    {
        if (!go)
        {
            go = new GameObject("AudioManager");
            go.AddComponent<SoundManager>();
        }
        else {
            DontDestroyOnLoad(go);
        }
        resourceAudioClips = Resources.LoadAll<AudioClip>("Sounds/");
        for(int i = 0;i<resourceAudioClips.Length;i++)
        {
            if (!audioDict.ContainsKey(resourceAudioClips[i].name))
            {
                audioDict.Add(resourceAudioClips[i].name, resourceAudioClips[i]);
            }
            else
            {
                break;
            }
        }
        
    }

    public void PhysicsRefresh(float fdt)
    {
       
    }

    public void PostInitialize()
    {
      // SoundManager.instance.PlayMusic("Theme", go, true);
    }

    public void Refresh(float dt)
    {
       
    }
    public void PlayMusic(string name,GameObject go, bool loop)
    {
        
        AudioSource activeSource =  go.AddComponent<AudioSource>();
        activeSource.clip = audioDict[name];
        activeSource.volume = 0.5f;
        activeSource.pitch = 0.8f;
        activeSource.Play();
        activeSource.loop = loop;

    }
    public void PlaySFX(string name,GameObject go)
    {
        AudioSource activeSource;
        if (go.GetComponent<AudioSource>())
        {
            activeSource = go.GetComponent<AudioSource>();
        }
        else
        {
            activeSource = go.AddComponent<AudioSource>();
          
        }
        activeSource.PlayOneShot(audioDict[name]);
        activeSource.volume = 1;
        activeSource.pitch = 1;
    }
    public void StopMusic(AudioSource[] audioSources)
    {
        if (isPlaying)
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].Stop();
                
            }
            isPlaying = false;
        }
        else
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].Play();
                
            }
            isPlaying = true;
        }
    }

}
