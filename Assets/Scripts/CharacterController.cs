using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector3 charPos;

    private void Start()
    {
        // rb = GetComponent<Rigidbody2D>(); Burada Caching yap�yoruz. Rigidbody2D'yi Cach ediyoruz. Karaktere ait componenti tan�mlamak.
        // animator = GetComponent<Animator>(); Caching. Animator Cach edilir. Karaktere ait Animator Componenti tan�mlan�r.

        charPos = transform.position;
    }

    private void FixedUpdate() // �uan ki durumda 50 fps yani
                               // Time Scale/Fixed Timestep (1/0,02)
    {
       // rb.velocity = Vector2.right * speed; //rb.velocity = new Vector2(x:speed, y:0f);
    }

    private void Update() //her frame �al���yor.
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos; //Hesaplad���m pozisyon karakterime i�lensin

        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            animator.SetFloat("Speed", 0.0f);
        }
        else
        {
            animator.SetFloat("Speed", speed);
        }

        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
        
    }
    private void LateUpdate()
    {
        mainCamera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }
}
