using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TestAIMovementController : MonoBehaviour
{
    Movement movement;

    [SerializeField]
    float horizontalCommuteRange = 30f;
    

    Vector3 homePos;

    void Start()
    {
        movement = GetComponent<Movement>();
        movement.SetMoveDirection(Vector3.right);

        homePos = transform.position;
    }
    
    void Update()
    {
        if((transform.position - homePos).x <= 0)
        {
            movement.SetMoveDirection(Vector3.right);
        }
        else if((transform.position - homePos).x >= horizontalCommuteRange)
        {
            movement.SetMoveDirection(-Vector3.right);
        }
        
        
    }
}
