using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class television : MonoBehaviour
{
    public AudioClip tvSound;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = tvSound;
        audioSource.Play();
    }
}
