using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISpeedDisplay : MonoBehaviour
{

    TextMeshProUGUI text;
    Movement movement;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    void Update()
    {
        text.text = movement.MaxSpeed.StatValue.ToString();
    }
}
