using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> Clip = new List<AudioClip>();

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAudioTheBeginning()
    {
        source.clip = Clip[0];
        source.Play();
    }

    public void OnTriggerAstronautPlay()
    {
        source.clip = Clip[1];
        source.Play();
    }
    
    public void PlayAudioLadder()
    {
        source.clip = Clip[2];
        source.Play();
    }

}



