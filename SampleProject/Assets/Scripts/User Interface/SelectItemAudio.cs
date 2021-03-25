using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemAudio : MonoBehaviour
{
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxis ("Vertical") != 0)
        {
            audioSource.Play();
        }
    }
}
