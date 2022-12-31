using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelected : MonoBehaviour
{
    public AudioSource audioSelect;
    public static AudioSelected instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayMusic()
    {
        audioSelect.Play();
    }
}
