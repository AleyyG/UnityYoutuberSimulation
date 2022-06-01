using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class books : MonoBehaviour
{
    public AudioClip[] booksSounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = booksSounds[Random.Range(0, booksSounds.Length)];
        audioSource.Play();
    }

}
