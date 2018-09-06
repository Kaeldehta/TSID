using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   
    [SerializeField]
    private float baseHealth = 100f;
    [SerializeField]
    private float healthIncrease = 0f;
    [SerializeField]
    private float healthMultiplier = 1f;

    public float MaxHealth
    {
        get
        {
            return (baseHealth + baseHealth * healthIncrease) * healthMultiplier;
        }
    }

    public float CurrentHealth { get; private set; }

    public event Action OnDeath = delegate { };
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void AddFlatHealth(float amount)
    {
        baseHealth += amount;
    }

    public void AddHealthIncrease(float increase)
    {
        healthIncrease += increase;
    }

    public void MultiplyHealth(float multiplier)
    {
        healthMultiplier *= multiplier;
    }

    void Die()
    {
        gameObject.SetActive(false);
        OnDeath();
        Destroy(gameObject, 2);
    }
    
    public float ChangeHealthByAmount(float amount)
    {
        float healthChange = amount + CurrentHealth > MaxHealth ? MaxHealth - CurrentHealth : amount;
        CurrentHealth += healthChange;

        if (CurrentHealth <= 0)
        {
            Die();
        }

        return healthChange;
    }
}
