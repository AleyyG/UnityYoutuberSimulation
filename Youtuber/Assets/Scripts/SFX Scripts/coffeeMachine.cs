using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeMachine : MonoBehaviour
{
    public AudioClip[] coffeeMachineSounds;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = coffeeMachineSounds[Random.Range(0, coffeeMachineSounds.Length)];
        audioSource.Play();
    }
}
