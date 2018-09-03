using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerMovementController : MonoBehaviour
{
    Movement movement;

    bool travelMode = false;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            travelMode = !travelMode;
        }

        Vector3 direction;
        if(travelMode)
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
