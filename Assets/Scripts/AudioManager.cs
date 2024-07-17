using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundSource;

    public AudioClip bgm;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip click;
    public AudioClip score;

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

}
