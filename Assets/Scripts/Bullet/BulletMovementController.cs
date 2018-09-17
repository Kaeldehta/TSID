using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementController : MonoBehaviour, IMovementController
{
    Movement movement;
    
    void Start()
    {
        movement = GetComponent<Movement>();
        movement.MoveDirection = transform.up;
    }

    
}
