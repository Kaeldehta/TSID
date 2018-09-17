using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Damage))]
public class BulletHitController : MonoBehaviour
{
    [SerializeField]
    private GameObject hitParticles = null;

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject hitObject = col.gameObject;
        
        if (GetComponent<Origin>().OriginGameObject != hitObject)
        {

            gameObject.SetActive(false);
            Vector3 hitPoint = col.GetContact(0).point;
            GameObject particle = Instantiate(hitParticles, hitPoint - Vector3.forward, Quaternion.identity);

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
                GetComponent<Damage>().ApplyDamage(hitObject, resistance);

            }

            Destroy(gameObject, 1);
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
