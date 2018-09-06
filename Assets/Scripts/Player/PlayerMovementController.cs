using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerMovementController : MonoBehaviour
{
    Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    public bool TravelMode { get; private set; } = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TravelMode = !TravelMode;

        }

        Vector3 direction;
        if (TravelMode)
        {
            direction = transform.up * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        }
        else
        {
            direction = Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
        }

        movement.MoveDirection = Vector3.ClampMagnitude(direction, 1);
    }

}
