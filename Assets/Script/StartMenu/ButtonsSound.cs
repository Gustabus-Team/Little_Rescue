using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip buttonClip;

    public void PlayButtonClip()
    {
        source.clip = buttonClip;
        source.Play();
    }

}
