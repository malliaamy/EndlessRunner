using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, coinSound, slideSound, hitSound;
    static AudioSource audioSourceClips;
    int Sound;
    // Start is called before the first frame update
    void Awake()
    {
        audioSourceClips = GetComponent<AudioSource>();
    }

    void Start()
    {
        jumpSound = Resources.Load<AudioClip> ("jumpSound");
        coinSound = Resources.Load<AudioClip> ("coinSound");
        slideSound = Resources.Load<AudioClip> ("slideSound");
        hitSound = Resources.Load<AudioClip> ("hitSound");
    }
    // Update is called once per frame
    void Update()
    {
        Sound = PlayerPrefs.GetInt("Sound");
        if (Sound == 1)
        {
            audioSourceClips.mute = true;
        }
        else
        {
            audioSourceClips.mute = false;
        }
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "jump":
            audioSourceClips.PlayOneShot(jumpSound);
            break;
            case "coin":
            audioSourceClips.PlayOneShot(coinSound);
            break;
            case "slide":
            audioSourceClips.PlayOneShot(slideSound);
            break;
            case "hit":
            audioSourceClips.PlayOneShot(hitSound);
            break;
        }
    }
}
