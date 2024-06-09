using Players;
using UnityEngine;

namespace Enemy
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 10;
        [SerializeField] private float damageInterval = 1f;

        private float damageTimer = 0f;

        private void Update()
        {
            if (damageTimer > 0)
                damageTimer -= Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && damageTimer <= 0)
            {
                var playerHealth = collision.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    var damageInfo = new DamageInfo(damageAmount, ElementType.Physic);
                    playerHealth.TakeDamage(damageInfo);
                    damageTimer = damageInterval;
                    var entityVisual = GetComponentInChildren<EntityVisual>();
                    if (entityVisual != null)
                        entityVisual.Attack();
                }
            }
        }
    }
}