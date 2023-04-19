using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {    
        boxCollider = GetComponent<BoxCollider2D>(); 
    }
    public void Get()
    { 
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.1f);
    }
    

}
