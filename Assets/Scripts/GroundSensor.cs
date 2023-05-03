using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerControler controller;
    
    public bool isGrounded;
    
    SFXManager sfxManager;

    SoundManager soundManager;

    
    // Start is called before the first frame update
    void Awake() 
    {
        controller = GetComponentInParent<PlayerControler>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            controller.anim.SetBool("IsJumping", false);
            
        }
        else if (other.gameObject.layer == 6)
        {
            Debug.Log("Moneda conseguida");

            Coin coin = other.gameObject.GetComponent<Coin>();
            coin.Get();
        }
         if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("Has muerto");
            soundManager.StopBGM();
            sfxManager.PersonajeDeath(); 

        }

    }
    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            controller.anim.SetBool("IsJumping", false);
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
            controller.anim.SetBool("IsJumping", true);
        }
    }
   
}
