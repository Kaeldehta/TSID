using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Damage))]
public class BulletDamageController : MonoBehaviour
{

    [SerializeField]
    private GameObject explosion;

    Damage damage;
    
    void Start()
    {
        damage = GetComponent<Damage>();
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(damage.Source != col.collider.gameObject)
        {
            GameObject particle = Instantiate(explosion, (Vector3)col.GetContact(0).point - Vector3.forward, Quaternion.identity);
            Color[] colors = col.collider.GetComponentInChildren<SpriteRenderer>().sprite.texture.GetPixels();
            
            Dictionary<Color, int> counts = new Dictionary<Color, int>();
            foreach(var color in colors)
            {
                if (counts.ContainsKey(color))
                {
                    counts[color]++;
                }
                else
                {
                    counts.Add(color, 1);
                }
            }

            int c = 0;
            Color maxColor = Color.black;
            foreach(var color in counts)
            {
                if(color.Value > 0)
                {
                    c = color.Value;
                    maxColor = color.Key;
                }
            }
            
            ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(maxColor);
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
