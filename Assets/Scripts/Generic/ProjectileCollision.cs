using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public static event Action<GameObject, GameObject, Vector2> OnAnyProjectileHit = delegate { };

    private bool destroyOnCollision = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;

        if(gameObject.GetComponent<Origin>().OriginGameObject != hitObject)
        {
            destroyOnCollision = true;
            OnAnyProjectileHit(gameObject, hitObject, collision.GetContact(0).point);
            if (destroyOnCollision)
            {
                gameObject.SetActive(false);
                Destroy(gameObject, 1);
            }

        }
    }

    public void SetDestroyOnCollision(bool value)
    {
        destroyOnCollision = value;
    }
}
