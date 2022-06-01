using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skateboard : MonoBehaviour
{
    public AudioClip skateboardSound;
    public AudioSource audioSource;
    private void OnMouseDown()
    {
        audioSource.PlayOneShot(skateboardSound);
    }
}
