using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    public AudioClip clockSound;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = clockSound;
        audioSource.Play();
    }
}
