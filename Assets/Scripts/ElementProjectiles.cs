using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectiles", menuName = "Create Projectiles", order = 0)]

public class ElementProjectiles : ScriptableObject
{
    [SerializeField] private Projectile fireProjectile;

    [SerializeField] private Projectile airProjectile;

    [SerializeField] private Projectile waterProjectile;

    [SerializeField] private Projectile earthProjectile;

    public Projectile GetProjectile(ElementType elementType)
    {
        return elementType switch
        {
            ElementType.Fire => fireProjectile,
            ElementType.Air => airProjectile,
            ElementType.Water => waterProjectile,
            ElementType.Earth => earthProjectile,
            _ => throw new ArgumentException()
        };
    }
}