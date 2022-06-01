using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Current;
    private void Awake()
    {
        Current = this;
        DontDestroyOnLoad(this);
    }
}
