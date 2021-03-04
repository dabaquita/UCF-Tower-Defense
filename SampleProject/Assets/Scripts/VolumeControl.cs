using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetBGMVolume (float sliderValue)
    {
        mixer.SetFloat("MusicExposed", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXVolume(float sliderValue)
    {
        mixer.SetFloat("SFXExposed", Mathf.Log10(sliderValue) * 20);
    }
}
