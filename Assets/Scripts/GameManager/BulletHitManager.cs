using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletHitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hitParticles = null;

    private void Start()
    {
        ProjectileCollision.OnAnyProjectileHit += HandleBulletCollision;
    }

    private void HandleBulletCollision(GameObject projectile, GameObject hitObject, Vector2 collisionPoint)
    {
        if(projectile.tag == "Bullet")
        {
            GameObject particle = Instantiate(hitParticles, (Vector3)collisionPoint - Vector3.forward, Quaternion.identity);

            Color color = GetMostUsedColor(hitObject.GetComponentInChildren<SpriteRenderer>().sprite.texture);

            ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(color);

            if (hitObject.GetComponent<Health>() != null)
            {
                float resistance = 0;
                if (hitObject.GetComponent<BulletResistance>() != null)
                {
                    resistance = hitObject.GetComponent<BulletResistance>().GetBulletResistance();
                }
                projectile.GetComponent<Damage>().ApplyDamage(hitObject, resistance);

            }
        }
        
    }
    
    Color GetMostUsedColor(Texture2D tex)
    {
        Color[] colors = tex.GetPixels();

        Dictionary<Color, int> counts = new Dictionary<Color, int>();
        foreach (var color in colors)
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
        foreach (var color in counts)
        {
            if (color.Value > 0)
            {
                c = color.Value;
                maxColor = color.Key;
            }
        }

        return maxColor;
    }
}
