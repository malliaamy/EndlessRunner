using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public static BGMusic instance;
    int Music;
    AudioSource audioSource;

    void Awake()
    {
        PlayerPrefs.SetInt("Music", 2);
        PlayerPrefs.SetInt("Sound", 2);

        audioSource = GetComponent<AudioSource>();
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        Music = PlayerPrefs.GetInt("Music");

        if (Music == 1)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }
}