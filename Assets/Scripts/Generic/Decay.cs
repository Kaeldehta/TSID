using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    
    [SerializeField]
    private float decayRange = 50f;

    private float decayCountdown;

    public static event Action<GameObject> OnAnyDecayed = delegate { };

    public float DecayRange
    {
        set
        {
            decayRange = value;
        }
    }

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if ((transform.position - startPos).magnitude > decayRange)
        {
            gameObject.SetActive(false);
            OnAnyDecayed(gameObject);
            Destroy(gameObject, 1);
        }
    }
}
