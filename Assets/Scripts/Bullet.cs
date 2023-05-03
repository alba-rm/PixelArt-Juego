using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rBody2D;

    public float bulletSpeed = 5;
    SFXManager sfxManager;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        rBody2D.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
        sfxManager.Bullet();

    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == 7)
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.Die();
            
        }
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Coin" || collider.gameObject.tag == "Bullet")
        {
            return;
        }
        
        Destroy(this.gameObject);
        
    }

}
