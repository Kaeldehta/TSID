using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    /// <summary>
    /// The maximum health amount of the gameObject
    /// </summary>
    [SerializeField]
    private float maxHealth;

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    /// <summary>
    /// The current health amount of the gameObject
    /// </summary>
    private float health;

    /// <summary>
    /// Event that triggers on death of the gameObject.
    /// </summary>
    public static event Action OnDeath = delegate { };

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Kills the gameObject and invokes OnDeath event.
    /// </summary>
    private void Die()
    {
        gameObject.SetActive(false);
        OnDeath();
        Destroy(gameObject, 5);
    }

    /// <summary>
    /// Adds or substracts specified amount to or from maxHealth of the gameObject.
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeMaxHealthByAmount(float amount)
    {
        maxHealth += amount;
    }

    /// <summary>
    /// Multiplies the maxHealth of the gameObject by specified multiplier.
    /// </summary>
    /// <param name="multiplier"></param>
    public void ChangeMaxHealthByMultiplier(float multiplier)
    {
        maxHealth *= multiplier;
    }

    /// <summary>
    /// Damage or heal the gameObject by specified amount.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>Returns the real amount by what health has changed.</returns>
    public float ChangeHealthByAmount(float amount)
    {
        float healthChange = amount + health > maxHealth ? maxHealth - health : amount;
        health += healthChange;
        return healthChange;
    }
}
