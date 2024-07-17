using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource soundSource;

    public AudioClip bgm;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip click;
    public AudioClip score;
    public AudioClip power;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void playBGM()
    {
        soundSource.clip = bgm;
        soundSource.Play();
    }

    public void jumpSFX()
    {
        soundSource.PlayOneShot(jump);
    }

    public void deathSFX()
    {
        soundSource.PlayOneShot(death);
    }
    public void clickSFX()
    {
        soundSource.PlayOneShot(click);
    }

    public void scoreSFX()
    {
        soundSource.PlayOneShot(score);
    }

    public void powerSFX()
    {
        soundSource.PlayOneShot(power);
    }

}
