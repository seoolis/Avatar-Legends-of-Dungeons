using UnityEngine;

public struct DamageInfo
{
    public int Damage { get; }

    public ElementType Element { get; }

    /// <summary>
    /// Позиция удара в мировых координатах.
    /// </summary>
    public Vector3 Position { get; }

    /// <param name="position">Позиция удара в мировых координатах.</param>
    public DamageInfo(int damage = 0,
        ElementType elementType = ElementType.Physic,
        Vector3 position = default)
    {
        Damage = damage;
        Element = elementType;
        Position = position;
    }
}