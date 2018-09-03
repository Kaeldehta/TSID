using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 10f;

    [SerializeField]
    private float speedIncrease = 0f;

    public Vector3 MoveDirection { get; set; }

    public float MaxSpeed
    {
        get
        {
            return baseSpeed + baseSpeed * speedIncrease;
        }
    }

    public float CurrentSpeed
    {
        get
        {
            return (MoveDirection * MaxSpeed).magnitude;
        }
    }

    void Start()
    {
        MoveDirection = Vector3.zero;
    }

    void Update()
    {
        transform.position += MoveDirection * Time.deltaTime * MaxSpeed;
    }
    
    public void AddFlatSpeed(float amount)
    {
        baseSpeed += amount;
    }

    public void AddSpeedIncrease(float increase)
    {
        speedIncrease += increase;
    }

}
