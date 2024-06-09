using UnityEngine.Events;

public interface IHealth
{
    public int Health { get; }
    public UnityEvent<int, int> OnUpdateHealth { get; }
    public void IncreaseHealth(int value);
    public void DecreaseHealth(int value);
}