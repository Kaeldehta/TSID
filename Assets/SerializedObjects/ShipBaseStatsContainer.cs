using UnityEngine;

[CreateAssetMenu(fileName = "New ShipBaseStatsContainer", menuName = "BaseContainer/ShipStats", order = 1)]
public class ShipBaseStatsContainer : ScriptableObject
{
    public float baseHealth;
    public float baseSpeed;
    public float baseShotsPerSecond;
    public int baseProjectilesPerShot;
    public float baseProjectileSpeed;
    public float baseDamage;
}
