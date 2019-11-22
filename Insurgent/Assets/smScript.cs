using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smScript : MonoBehaviour
{
    public static AudioClip playerShoot, playerKick, fireballSound, playerDeath, coinsound;
    static AudioSource audioSrc;

    void Start()
    {
        coinsound = Resources.Load<AudioClip>("coin-sound");
        fireballSound = Resources.Load<AudioClip>("fire_shoot1");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin-sound":
                audioSrc.PlayOneShot(coinsound);
                break;
            case "fire_shoot1":
                audioSrc.PlayOneShot(fireballSound);
                break;
        }
    }
}
