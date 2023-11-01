using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AudioSource deathSoundEffect;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Die();
    }


    private void Die()
    {
        if(Health.totalHealth <= 0)
        {
            deathSoundEffect.Play();
            animator.SetTrigger("health");
        }
    }

    private void RestartLevel()
    {
        deathSoundEffect.Play();
        Health.totalHealth = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
