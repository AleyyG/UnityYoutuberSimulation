using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wateringPlant : MonoBehaviour
{
    public AudioClip waterPlant;
    public AudioSource audioSource;
    private void OnMouseDown()
    {
        audioSource.clip = waterPlant;
        audioSource.Play();
    }
}
