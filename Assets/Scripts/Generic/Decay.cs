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

    Vector3 oldPos;
    float counter;

    void Start()
    {
        oldPos = transform.position;
        counter = 0;
    }

    void Update()
    {
        if (counter > decayRange)
        {
            gameObject.SetActive(false);
            OnAnyDecayed(gameObject);
            Destroy(gameObject, 1);
        }
        counter += (transform.position - oldPos).magnitude;
        oldPos = transform.position;
    }
}
