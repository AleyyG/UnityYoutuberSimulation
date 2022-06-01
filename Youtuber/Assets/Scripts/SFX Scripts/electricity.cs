using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricity : MonoBehaviour
{
    public AudioClip[] electricitySounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = electricitySounds[Random.Range(0, electricitySounds.Length)];
        audioSource.Play();
    }
}
