using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    //This version of sound creation was unnecessarily complicated for my first time
    //Handled sound management much better in subsequent games
    public enum Sound //use of enums could be replaced by array[]
    {
        PlayerJump,
        Score,
        Lose,
        Over100,
        Over200,
        NewHighscore,
        StartScreen,
    }
    public static void PlaySound(Sound sound) //create a new gameobject called "Sound" and gives it an AudioSource
                                              //then plays an AudioSource based on GetAudioClip()
                                              //checking that the input sound exists in the array inside of a class inside the GameAssets class
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }
    private static AudioClip GetAudioClip(Sound sound)//checks each sound in 
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.GetInstance().soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        return null; //if valid sound cannot be find then return null
    }
}//class
