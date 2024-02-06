using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject _camera;

    private Vector3 charPos;

    private void Start()
    {
        // rb = GetComponent<Rigidbody2D>(); Burada Caching yapýyoruz. Rigidbody2D'yi Cach ediyoruz. Karaktere ait componenti tanýmlamak.
        // animator = GetComponent<Animator>(); Caching. Animator Cach edilir. Karaktere ait Animator Componenti tanýmlanýr.

        charPos = transform.position;
    }

    private void FixedUpdate() // Þuan ki durumda 50 fps yani
                               // Time Scale/Fixed Timestep (1/0,02)
    {
       // rb.velocity = Vector2.right * speed; //rb.velocity = new Vector2(x:speed, y:0f);
    }

    private void Update() //her frame çalýþýyor.
    {
        if(Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            //Debug.Log("Hýz 1.0f");
        }
        else
        {
            speed = 0.0f;
            //Debug.Log("Hýz 0.0f"); 
        }
        charPos = new Vector3(charPos.x + (speed * Time.deltaTime), charPos.y);
        transform.position = charPos; //Hesapladýðým pozisyon karakterime iþlensin
        animator.SetFloat("Speed", speed);
    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }
}
