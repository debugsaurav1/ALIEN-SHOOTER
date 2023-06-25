using System;
//using UnityEditor.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update

    private void Awake()
    {
        foreach (Sound s in sounds)
        {   
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
        }
    }


    void Start()
    {
       
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log(sounds);
        if(s == null )
            return;
        s.source.Play();
    }
}
