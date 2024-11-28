using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioClip[] walkingClips;
    public AudioClip jumpClip;
    public AudioClip landClip;

    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip, 0.4f);
    }

    private void Jump()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    private void Land()
    {
        audioSource.PlayOneShot(landClip);
    }

    private AudioClip GetRandomClip()
    {
        return walkingClips[UnityEngine.Random.Range(0, walkingClips.Length)];
    }
}
