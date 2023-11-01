using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollection : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
        else if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            score += 10;
            scoreText.text = "Score: " + score;
        }
    }
}
