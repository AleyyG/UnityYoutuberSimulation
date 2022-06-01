using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public AudioClip cameraSound;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = cameraSound;
        audioSource.Play();
    }
}
