using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonIndex controller;
    public bool disableOnce;

    void PlaySound(AudioClip sound)
    {
        if(!disableOnce)
        {
            controller.audioSource.PlayOneShot(sound);
        }
        else 
        {
            disableOnce = false;
        }
    }
}
