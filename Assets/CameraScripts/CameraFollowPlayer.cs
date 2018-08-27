using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float followSpeed = 10f;

    [SerializeField]
    private float zoom = 25f;
     
    void LateUpdate()
    {
        Vector3 newPos = player.transform.position;
        newPos.z = -zoom;
        transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * followSpeed);
    }
}
