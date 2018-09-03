using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthRegen : MonoBehaviour
{
    /// <summary>
    /// The percentage of maxHealth of the gameObject that regenerates per second.
    /// </summary>
    [SerializeField]
    [Range(-1f, 1f)]
    private float percentRegenPerSec = 0f;

    Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        float regenAmount = health.MaxHealth * percentRegenPerSec * Time.deltaTime;
        health.ChangeHealthByAmount(regenAmount);
    }

    /// <summary>
    /// Adds or substracts specified amount to or from percentRegenPerSec of the gameObject.
    /// </summary>
    /// <param name="amount"></param>
    public void ChangePercentRegenPerSecByAmount(float amount)
    {
        percentRegenPerSec += amount;
    }
}
