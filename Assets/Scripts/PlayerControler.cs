using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float playerSpeed = 2f;
    public float jumpForce = 4f;
    float horizontal;
    private Rigidbody2D rBody;
    private SpriteRenderer spriteRenderer;
    private GroundSensor sensor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        
        }
        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }
}
