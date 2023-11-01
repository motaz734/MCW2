using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrain : MonoBehaviour
{
    public float damageCoefficient = 0.05f;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private SpriteRenderer sprite;
    private void Start()
    {
       sprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }

    private void FixedUpdate()
    {
        DrainHealth();
    }

    private void DrainHealth()
    {
        Health.totalHealth -= damageCoefficient * Time.deltaTime;
        SetSize(Health.totalHealth);
    }

    private void SetSize(float size)
    {
        healthBar.localScale = new Vector3(size, 1f);
    }
    
}
