using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    public AudioClip[] bookSounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = bookSounds[Random.Range(0, bookSounds.Length)];
        audioSource.Play();
    }
}
