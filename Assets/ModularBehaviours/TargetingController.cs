using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingController : MonoBehaviour
{
    private GameObject target;
    private Weapon weapon;
    private Movement projMovement;

    [SerializeField]
    private Sprite crossHairSprite;

    GameObject crossHair;

    Vector3 mousePos;

    List<GameObject> bulletsInCircle;

    GameObject lastBullet;

    void Start()
    {
        crossHair = new GameObject("crosshair", typeof(SpriteRenderer));
        crossHair.GetComponent<SpriteRenderer>().sprite = crossHairSprite;
        crossHair.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        crossHair.GetComponent<SpriteRenderer>().sortingOrder = 1;
        crossHair.transform.localScale = new Vector3(5, 5, 5);

        weapon = GetComponent<Weapon>();
        projMovement = weapon.ProjMovementComp;

    }

    void Update()
    {
        Ray mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane xy = new Plane(Vector3.forward, Vector3.zero);
        float distance;
        xy.Raycast(mousePosRay, out distance);
        mousePos = mousePosRay.GetPoint(distance);

        Vector3 posToMouse = mousePos - transform.position;

        //Range -180 +180

        int dir = (int)Vector3.Cross(posToMouse, transform.up * posToMouse.magnitude).z;

        float l = (posToMouse - transform.up * posToMouse.magnitude).magnitude;

        //Vector3 rotated = rotation * transform.up * posToMouse.magnitude;

        //Vector3 rotated = Vector3.RotateTowards(transform.up * posToMouse.magnitude, transform.right, Time.deltaTime * l * projMovement.Speed * 5, 0);

        Vector3 rotated = mousePos + transform.right * -dir * l * projMovement.Speed * Time.deltaTime;

        crossHair.transform.position = rotated;

        //Collider2D[] collidersInCircle = Physics2D.OverlapCircleAll(transform.position, posToMouse.magnitude);

        //foreach(var col in collidersInCircle)
        //{
        //    if(col.GetComponent<Damage>() != null)
        //    {
        //        if (col.GetComponent<Damage>().Source == gameObject)
        //        {
        //            if(lastBullet == null)
        //            {
        //                lastBullet = col.gameObject;
        //            }
        //            else if((col.transform.position - transform.position).magnitude < (lastBullet.transform.position - transform.position).magnitude)
        //            {
        //                lastBullet = col.gameObject;
        //            }
        //        }
        //    }

        //}



        //crossHair.transform.position = transform.position + lastBullet.transform.up * posToMouse.magnitude;

    }

}
