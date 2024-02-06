using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Rigidbody2D rd;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool moving;
    private bool jump;
    private bool grounded = true;
    private float moveDirection;

    private void Awake()
    {
        //anim = GetComponent<Animator>(); Caching 
        //spriteRenderer = GetComponent<SpriteRenderer>(); Caching 
    }

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rd.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        rd.velocity = new Vector2(speed * moveDirection, rd.velocity.y);
        if (jump == true)
        {
            rd.velocity = new Vector2(rd.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) )
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                spriteRenderer.flipX = true;
                anim.SetFloat("Speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                spriteRenderer.flipX = false;
                anim.SetFloat("Speed", speed);

            }
        }
        else if (grounded == true)
        {
        
            moveDirection = 0.0f;
        
            anim.SetFloat("Speed", 0.0f);
        
        }

        if ( grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("Jump");
            anim.SetBool("grounded", false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag( "floor"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }

    }
}
