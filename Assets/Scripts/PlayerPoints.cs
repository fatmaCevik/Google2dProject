using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource pickingSound;

    private void Awake()
    {
        scoreText.text = Score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("diamond"))
        {
            pickingSound.Play();
            Destroy(collision.gameObject);
            Score.totalScore ++;
            scoreText.text = Score.totalScore.ToString();
        }
    }
}
