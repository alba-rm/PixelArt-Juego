using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip personajeDeath;
   
    public AudioClip getCoin;
    
    public AudioClip chest;

    public AudioClip bullet;

    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PersonajeDeath()
    {
        source.PlayOneShot(personajeDeath);
    }

    public void GetCoin()
    {
        source.PlayOneShot(getCoin);
    }
    public void Chest()
    {
        source.PlayOneShot(chest);
    }
    public void Bullet()
    {
        source.PlayOneShot(bullet);
    }

}
