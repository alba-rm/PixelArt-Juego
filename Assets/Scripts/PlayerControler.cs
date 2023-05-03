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
    public Animator anim;

    GameManager gameManager;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //spriteRenderer.flipX = false;
            anim.SetBool("IsRunning", true);
        
        }
        else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //spriteRenderer.flipX = true;
            anim.SetBool("IsRunning", true);
        
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }

}
