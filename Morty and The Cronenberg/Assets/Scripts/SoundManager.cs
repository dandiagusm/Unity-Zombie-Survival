using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip CountDown, Shoot, Aww, ChillMusic, DeathVoice, GameOver, ZombieBG, ZombieHit, Jump;
    public static AudioSource AudioSrc;

    public static float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Shoot = Resources.Load<AudioClip>("Shoot");
        CountDown = Resources.Load<AudioClip>("CountDown");
        Aww = Resources.Load<AudioClip>("Aww");
        ChillMusic = Resources.Load<AudioClip>("ChillMusic");
        DeathVoice = Resources.Load<AudioClip>("DeathVoice");
        GameOver = Resources.Load<AudioClip>("GameOver");
        ZombieBG = Resources.Load<AudioClip>("ZombieBG");
        ZombieHit = Resources.Load<AudioClip>("ZombieHit");
        Jump = Resources.Load<AudioClip>("Jump");

        AudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //test
        musicVolume = Sound.volume;
        AudioSrc.volume = musicVolume;
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Shoot" :
                AudioSrc.PlayOneShot(Shoot);
                break;
            case "Aww":
                AudioSrc.PlayOneShot(Aww);
                break;
            case "ChillMusic":
                AudioSrc.PlayOneShot(ChillMusic);
                break;
            case "DeathVoice":
                AudioSrc.PlayOneShot(DeathVoice);
                break;
            case "GameOver":
                AudioSrc.PlayOneShot(GameOver);
                break;
            case "ZombieBG":
                AudioSrc.PlayOneShot(ZombieBG);
                break;
            case "ZombieHit":
                AudioSrc.PlayOneShot(ZombieHit);
                break;
            case "CountDown":
                AudioSrc.PlayOneShot(CountDown);
                break;
            case "Jump":
                AudioSrc.PlayOneShot(Jump);
                break;
        }
    }

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public static void SetVolume(float vol)
    {
        musicVolume = vol;
    }

}
