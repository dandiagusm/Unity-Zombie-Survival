using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip otherClip;
    public AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        play();
    }

    public void play()
    {
        Audio.clip = otherClip;
        Audio.volume = Sound.volume;
        Audio.Play();

        //test
    }
}
