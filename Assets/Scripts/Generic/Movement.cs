using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Stat MaxSpeed;

    public Vector3 MoveDirection { get; set; } = Vector3.zero;
    
    public float CurrentSpeed
    {
        get
        {
            return (MoveDirection * MaxSpeed.StatValue).magnitude;
        }
    }
    
    void Update()
    {
        transform.position += MoveDirection * Time.deltaTime * MaxSpeed.StatValue;
    }
    

}
