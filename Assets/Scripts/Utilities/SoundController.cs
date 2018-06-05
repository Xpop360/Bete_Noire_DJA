using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public Sound[] sounds;

    Animator playerAnimator;

    public static SoundController mysoundcontroller;
    [HideInInspector]
    public bool onceFootsteps = true;
    SceneManager scenemanager;

    public static Sound[] soundinstance;

    void Awake()
    {
        soundinstance = new Sound[sounds.Length];

        if(mysoundcontroller==null)
        {
            mysoundcontroller = this;
            this.tag = "SoundManager";
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        soundinstance = sounds;
    }

    void Start()
    {

    }

    public static void Play(string name)
    {
        Sound s = Array.Find<Sound>(soundinstance, soundinstance => soundinstance.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is null");
            return;
        }
        s.source.Play();
    }

    public static void Stop(string name)
    {
        Sound s = Array.Find<Sound>(soundinstance, soundinstance => soundinstance.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is null");
            return;
        }
        s.source.Stop();
    }

    public static void StopAll()
    {
        AudioSource[] audioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource a in audioSources)
        {
            a.Stop();
        }
    }
}