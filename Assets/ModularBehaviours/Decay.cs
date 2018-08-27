using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{

    [SerializeField]
    private float decayTime = 5f;

    private float decayCountdown;

    void Start()
    {
        decayCountdown = decayTime;
    }

    void Update()
    {
        if (decayCountdown <= 0)
        {
            //Debug.Log((gameObject.transform.position - GetComponent<Damage>().Source.transform.position).magnitude);
            Destroy(gameObject);
        }
        decayCountdown -= Time.deltaTime;
    }
}
