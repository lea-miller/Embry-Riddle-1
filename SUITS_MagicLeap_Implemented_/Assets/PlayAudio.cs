using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GameObject.FindWithTag("Main Screen").GetComponent<AudioSource>();
    }

    public void playAudio(AudioClip clip, int volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
