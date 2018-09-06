using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDPPDisplay : MonoBehaviour
{

    TextMeshProUGUI text;
    Weapon weapon;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
    }

    void Update()
    {
        text.text = weapon.Projectile.GetComponent<Damage>().RealDamage.ToString();
    }
}
