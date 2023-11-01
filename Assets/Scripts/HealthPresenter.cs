using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] Health health;
    private RectTransform bar; 


    void Start()
    {
        bar = GetComponent<RectTransform>();
        Health.totalHealth = 1f;

        if (health != null)
        {
            health.HealthChanged += OnHealthChanged;
        }
        UpdateView();
    }

    public void UpdateView()
    {
        if (health == null)
            return;

        if (bar != null && health.MaxHealth != 0)
        {
            bar.localScale = new Vector3(Health.totalHealth, health.MaxHealth);
        }
    }

    public void Reset()
    {
        health?.Restore();
    }

    public void Damage(float damage)
    {
        if((Health.totalHealth -= damage) >= 0f)
        {
            health?.Decrement(damage);
        }
        else
        {
            Health.totalHealth = 0f;
        }

    }

    public void OnHealthChanged()
    {
        UpdateView();
    }

    
}
