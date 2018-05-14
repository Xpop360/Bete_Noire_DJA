using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundController : MonoBehaviour
{
    public Sound[] sounds;

    Animator playerAnimator;

    public static SoundController instance;
    [HideInInspector]
    public bool onceFootsteps = true;

    // Use this for initialization
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
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
    }

    void Start()
    {
        Play("Thunder");
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (playerAnimator.GetBool("isWalking"))
        {
            //Debug.Log("Sounding Footsteps");
            if (onceFootsteps)
            {
                Play("Footsteps1");
                onceFootsteps = false;
            }
        }
        else
        {
            Stop("Footsteps1");
            onceFootsteps = true;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find<Sound>(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is null");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find<Sound>(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is null");
            return;
        }
        s.source.Stop();
    }
}