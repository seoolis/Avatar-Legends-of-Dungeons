[System.Serializable]

public enum ElementType { Physic, Fire, Earth, Air, Water }

public static class ElementTypeExtensions
{
    private static readonly bool[,] elemenetsDamageable = new bool[5, 5]
    {
        //P    F     E     A     W
        {true, true, true, true, true},     // Physic
        {true, false, true, false, true},   // Fire
        {true, true, false, true, false},   // Earth
        {true, false, true, false, true},   // Air
        {true, true, false, true, false}    // Water
    };

    public static bool IsDamageable(this ElementType elementType, ElementType elementType2)
    {
        return elemenetsDamageable[(int)elementType, (int)elementType2];
    }
}