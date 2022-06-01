using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    public AudioClip bedSound;
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.clip = bedSound;
        audioSource.Play();
    }
}
