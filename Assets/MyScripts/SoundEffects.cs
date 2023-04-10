using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource pop;
    public AudioClip sfx1, sfx2;

    public void PlayWoodenDoorSound()
    {
        pop.clip = sfx1;
        pop.Play();
    }

    public void PlayBarredGateSound()
    {
        pop.clip = sfx2;
        pop.Play();
    }
}

