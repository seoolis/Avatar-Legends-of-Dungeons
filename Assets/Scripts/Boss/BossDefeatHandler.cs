using UnityEngine;
using Enemy;

public class BossDefeatHandler : MonoBehaviour
{
    [SerializeField]
    private ElementType elementToAward;

    private EnemyHealth enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        if (enemyHealth != null)
            enemyHealth.OnDie.AddListener(OnBossDefeated);
        else
            Debug.LogError("Компонент EnemyHealth не найден в объекте boss.");
    }

    private void OnBossDefeated()
    {
        Players.Player.Instance.AcquireElement(elementToAward);
        Debug.Log($"Player приобрёл {elementToAward} элемент.");
    }
}
