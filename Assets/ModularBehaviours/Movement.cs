using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    
    private Vector3 moveDirection;

    public Vector3 MoveDirection
    {
        get
        {
            return moveDirection;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    void Start()
    {
        moveDirection = Vector3.zero;
    }

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * speed;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void ChangeSpeedByAmount(float amount)
    {
        speed += amount;
    }
    
}
