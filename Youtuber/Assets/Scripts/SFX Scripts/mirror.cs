using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    public AudioClip[] mirrorSounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = mirrorSounds[Random.Range(0, mirrorSounds.Length)];
        audioSource.Play();
    }
}
