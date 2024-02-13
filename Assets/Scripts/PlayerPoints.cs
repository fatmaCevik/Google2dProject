using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private AudioSource pickingSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("diamond"))
        {
            pickingSound.Play();
            Destroy(collision.gameObject);
            score++;
        }
    }
}
