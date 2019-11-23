using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smScript : MonoBehaviour
{
    public static AudioClip playerShoot, playerShoot2, playerKick, playercharge, kickhit, fireballSound, playerDeath, coinsound, batattack, batdie;
    static AudioSource audioSrc;

    void Start()
    {
        coinsound = Resources.Load<AudioClip>("coin-sound");
        fireballSound = Resources.Load<AudioClip>("fire_shoot1");
        batattack = Resources.Load<AudioClip>("bat/Attack2");
        batdie = Resources.Load<AudioClip>("bat/Die1");
        playerShoot = Resources.Load<AudioClip>("playershoot");
        playerShoot2 = Resources.Load<AudioClip>("playershoot2");
        playerShoot2 = Resources.Load<AudioClip>("playershoot2");
        playercharge = Resources.Load<AudioClip>("chargeattack");
        playerKick = Resources.Load<AudioClip>("kick-attack");
        kickhit = Resources.Load<AudioClip>("kick-hit");

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
            case "bat/Attack2":
                audioSrc.PlayOneShot(batattack);
                break;
            case "bat/Die1":
                audioSrc.PlayOneShot(batdie);
                break;
            case "playershoot":
                audioSrc.PlayOneShot(playerShoot);
                break;
            case "playershoot2":
                audioSrc.PlayOneShot(playerShoot2);
                break;
            case "chargeattack":
                audioSrc.PlayOneShot(playercharge);
                break;
            case "kick-attack":
                audioSrc.PlayOneShot(playerKick);
                break;
            case "kick-hit":
                audioSrc.PlayOneShot(kickhit);
                break;
        }
    }

    public static void StopSound(string clip)
    {
        switch (clip)
        {
            case "stop":
                audioSrc.Stop();
                break;
        }
    }
}