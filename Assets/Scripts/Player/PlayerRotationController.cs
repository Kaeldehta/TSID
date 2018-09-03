using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class PlayerRotationController : MonoBehaviour
{
    private Rotation rotation;

    void Start()
    {
        rotation = GetComponent<Rotation>();
    }

    void Update()
    {
        Ray mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane xy = new Plane(Vector3.forward, Vector3.zero);
        float distance;
        xy.Raycast(mousePosRay, out distance);
        Vector3 mousePos = mousePosRay.GetPoint(distance);
        Vector3 lookDirection = mousePos - transform.position;
        lookDirection.Normalize();
        Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        rotation.SetNewRotation(newRotation);
        
    }
}
