using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;
    public static float totalHealth;
    private const float maxHealth = 1f;
    public const float minHealth = 0f;

    public float CurrentHealth { get => totalHealth; set => totalHealth = value; }
    public float MinHealth => minHealth;
    public float MaxHealth => maxHealth;

    public void Increment(float amount)
    {
        totalHealth += amount;
        totalHealth = Mathf.Clamp(totalHealth, minHealth, maxHealth);
        UpdateHealth();
    }

    public void Decrement(float amount)
    {
        totalHealth -= amount;
        totalHealth = Mathf.Clamp(totalHealth, minHealth, maxHealth);
        UpdateHealth();
    }

    public void Restore()
    {
        totalHealth = maxHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        HealthChanged?.Invoke();
    }
}
