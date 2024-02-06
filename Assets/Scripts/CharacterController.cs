using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Start()
    {
        // rb = GetComponent<Rigidbody2D>(); Burada Caching yap�yoruz. Rigidbody2D'yi Cach ediyoruz. Karaktere ait componenti tan�mlamak.
        // animator = GetComponent<Animator>(); Caching. Animator Cach edilir. Karaktere ait Animator Componenti tan�mlan�r.
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            Debug.Log("H�z 1.0f");
        }
        else
        {
            speed = 0.0f;
            Debug.Log("H�z 0.0f"); 
        }

        animator.SetFloat("Speed", speed);
        rb.velocity = Vector2.right * speed; //rb.velocity = new Vector2(x:speed, y:0f);
    }
}
