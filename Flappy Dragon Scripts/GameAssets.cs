using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAssets : MonoBehaviour
{

    private static GameAssets instance;
    public static GameAssets GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
       instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))//resets game when you leftclick, this was for de-bugging purposes
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public Transform Pipe1;
    public Transform Pipe2;

    //complicated sound management, will not do it like this again
    public SoundAudioClip[] soundAudioClipArray;

    [Serializable]public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}//class
