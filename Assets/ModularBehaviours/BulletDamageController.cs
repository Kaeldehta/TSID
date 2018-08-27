using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damage))]
public class BulletDamageController : MonoBehaviour
{

    Damage damage;
    
    void Start()
    {
        damage = GetComponent<Damage>();
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(damage.Source != col.collider.gameObject)
        {
            float resistance = 0;
            if(col.collider.gameObject.GetComponent<BulletResistance>() != null)
            {
                resistance = col.collider.gameObject.GetComponent<BulletResistance>().GetBulletResistance();
            }
            damage.ApplyDamage(col.collider.gameObject, resistance);
            Destroy(gameObject);
        }
        
    }
}
