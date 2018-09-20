using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    Health health;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    
    void Update()
    {
        text.text = Mathf.RoundToInt(health.CurrentHealth).ToString() + "/" + health.MaxHealth.StatValue.ToString();
    }
}
