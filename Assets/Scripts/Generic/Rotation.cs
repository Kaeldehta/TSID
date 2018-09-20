using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 0.2f;

    private Quaternion newRotation;

    void Start()
    {
        newRotation = transform.rotation;
        
    }
    
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

    public void SetNewRotation(Quaternion rotation)
    {
        newRotation = rotation;
    }

    public void SetRotationSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}
