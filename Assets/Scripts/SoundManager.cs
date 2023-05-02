using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Music;

    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();

        source.clip = Music;
        source.Play();


    }
    public void StopBGM()
    {
        source.Stop();
    }
}
