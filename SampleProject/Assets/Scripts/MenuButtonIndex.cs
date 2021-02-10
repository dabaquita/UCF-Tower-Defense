using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a class that listens for user key input and generates an index value 
// based on which key is pressed
public class MenuButtonIndex : MonoBehaviour
{
    public int index;
    [SerializeField] bool keyPressed;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {

            if(!keyPressed)
            {
                if(Input.GetAxis("Vertical") < 0)
                {
                    if(index < maxIndex)
                    {
                        index++;
                    } 
                    else 
                    {
                        index = 0; // Got to beginning of button list
                    }
                    
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else 
                    {
                        index = maxIndex; // Go to the end of button list
                    }
                }
                audioSource.Play();
                keyPressed = true;
            }
        }
        else 
        {
            keyPressed = false; // Stops user from spamming the down/up key
        }
    }
}
