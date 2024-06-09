using Players;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth, IDamageable
    {
        public EntityVisual entityVisual;
        
        [field: SerializeField]
        public int Health { get; private set; }

        [field: SerializeField]
        public ElementType Element { get; private set; }

        [field: SerializeField]
        public UnityEvent<int, int> OnUpdateHealth { get; set; }

        public UnityEvent OnDie;

        public void DecreaseHealth(int value)
        {
            var oldHealth = Health;
            Health -= value;
            if (Health <= 0)
                Die();
            OnUpdateHealth?.Invoke(oldHealth, Health);
        }

        public void IncreaseHealth(int value)
        {
            var oldHealth = Health;
            Health += value;
            OnUpdateHealth?.Invoke(oldHealth, Health);
        }

        public void Die()
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }

        public void TakeDamage(DamageInfo damageInfo)
        {
            var damage = damageInfo.Damage;
            var element = damageInfo.Element;
            var isTakeDamage = Element.IsDamageable(element);
            if (isTakeDamage)
                DecreaseHealth(damage);
        }
    }
}