using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wardrobe : MonoBehaviour
{
    public AudioClip wardrobeSound;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = wardrobeSound;
        audioSource.Play();
    }
}
