using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffe : MonoBehaviour
{
    public AudioClip[] coffeeSounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = coffeeSounds[Random.Range(0, coffeeSounds.Length)];
        audioSource.Play();
    }
}
