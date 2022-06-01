using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer : MonoBehaviour
{
    public AudioClip[] drawerSounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = drawerSounds[Random.Range(0, drawerSounds.Length)];
        audioSource.Play();
    }
}
