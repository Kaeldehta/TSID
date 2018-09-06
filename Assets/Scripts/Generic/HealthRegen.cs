using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthRegen : MonoBehaviour
{
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
    
    public void ChangePercentRegenPerSecByAmount(float amount)
    {
        percentRegenPerSec += amount;
    }
}
