using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private Quaternion newRotation;

    void Start()
    {
        newRotation = Quaternion.identity;
        
    }
    
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

    public void SetNewRotation(Quaternion rotation)
    {
        newRotation = rotation;
    }
}
