using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speaker : MonoBehaviour
{
    public AudioClip[] speakerSounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = speakerSounds[Random.Range(0, speakerSounds.Length)];
        audioSource.Play();
    }
}
