using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Boost : MonoBehaviour
{

    Movement movement;

    [SerializeField]
    private float boostSpeed = 1f;

    [SerializeField]
    private float boostAmount;

    bool accel = false;
    bool deccel = false;
    float speedChangeAccel;
    float speedChangeDeccel;


    void Start()
    {
        movement = GetComponent<Movement>();
        speedChangeAccel = 0;
        speedChangeDeccel = boostAmount;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
        {
            accel = true;
            deccel = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            accel = false;
            deccel = true;
        }
        if (accel && !deccel)
        {
            float change = Time.deltaTime * boostSpeed;
            if (speedChangeAccel + change < boostAmount)
            {
                movement.AddFlatSpeed(change);
                speedChangeAccel += change;
                speedChangeDeccel -= change;
            }
            else if (speedChangeAccel + change >= boostAmount)
            {
                movement.AddFlatSpeed(speedChangeDeccel);
                speedChangeAccel = boostAmount;
                speedChangeDeccel = 0;
                accel = false;
                deccel = false;
            }
        }
        else if (!accel && deccel)
        {
            float change = Time.deltaTime * boostSpeed;
            if (speedChangeDeccel + change < boostAmount)
            {
                movement.AddFlatSpeed(-change);
                speedChangeAccel -= change;
                speedChangeDeccel += change;
            }
            else if (speedChangeDeccel + change >= boostAmount)
            {
                movement.AddFlatSpeed(-speedChangeAccel);
                speedChangeAccel = 0;
                speedChangeDeccel = boostAmount;
                accel = false;
                deccel = false;
            }
        }
    }
}
