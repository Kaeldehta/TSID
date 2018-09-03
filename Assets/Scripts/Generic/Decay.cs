using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{

    [SerializeField]
    private float decayTime = 5f;

    private float decayCountdown;

    public event Action OnDecayed = delegate { };

    public float DecayTime
    {
        set
        {
            decayTime = value;
        }
    }

    void Start()
    {
        decayCountdown = decayTime;
    }

    void Update()
    {
        if (decayCountdown <= 0)
        {
            gameObject.SetActive(false);
            OnDecayed();
            Destroy(gameObject, 5);
        }
        decayCountdown -= Time.deltaTime;
    }
}
