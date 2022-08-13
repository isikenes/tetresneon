using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] audios;
    private AudioSource source;
    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }


    public void PlayMoveAudio()
    {
        source.PlayOneShot(audios[0]);
    }

    public void PlayRotateAudio()
    {
        source.PlayOneShot(audios[1]);
    }

    public void PlayLineAudio()
    {
        source.PlayOneShot(audios[2]);
    }
}
