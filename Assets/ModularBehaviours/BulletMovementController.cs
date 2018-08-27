using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    Movement movement;
    
    void Start()
    {
        movement = GetComponent<Movement>();
        movement.SetMoveDirection(transform.up);
    }

    
}
