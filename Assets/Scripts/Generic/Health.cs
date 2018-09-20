using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public Stat MaxHealth;
    
    public float CurrentHealth { get; private set; }

    public event Action OnDeath = delegate { };

    void Start()
    {
        CurrentHealth = MaxHealth.StatValue;
    }
    
    void Die()
    {
        gameObject.SetActive(false);
        OnDeath();
        Destroy(gameObject, 2);
    }
    
    public float ChangeHealthByAmount(float amount)
    {
        float healthChange = amount + CurrentHealth > MaxHealth.StatValue ? MaxHealth.StatValue - CurrentHealth : amount;
        CurrentHealth += healthChange;

        if (CurrentHealth <= 0)
        {
            Die();
        }

        return healthChange;
    }
}
