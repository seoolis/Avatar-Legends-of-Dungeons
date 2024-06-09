using Enemy;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public EnemyHealth[] enemies;

    public TeleportTrigger teleport;

    private int enemyCount;
    
    private int deadEnemyCount;

    private void Start()
    {
        teleport.IsActive = false;
        enemyCount = enemies.Length;

        foreach (var enemy in enemies)
        {
            enemy.OnDie.AddListener(IncreaseDeadCount);
        }
    }

    private void IncreaseDeadCount()
    {
        deadEnemyCount++;
        if (deadEnemyCount >= enemyCount)
            teleport.IsActive = true;
    }
}