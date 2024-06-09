using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Players
{
    public class PlayerHealth : MonoBehaviour, IHealth, IDamageable
    {
        public bool Invincibility { get; set; }

        public int Health { get; private set; }

        [field: SerializeField]
        public int MaxHealth { get; private set; }

        [field: SerializeField]
        public UnityEvent<int, int> OnUpdateHealth { get; set; }

        private void Awake()
        {
            Health = MaxHealth;
        }

        public void DecreaseHealth(int value)
        {
            if (Invincibility) return;

            var oldHealth = Health;
            Health -= value;
            if (Health <= 0)
                Die();
            OnUpdateHealth?.Invoke(oldHealth, Health);
        }

        public void IncreaseHealth(int value)
        {
            var oldHealth = Health;
            Health = Mathf.Min(MaxHealth, Health + value);
            OnUpdateHealth?.Invoke(oldHealth, Health);
        }

        private void Die()
        {
            SceneManager.LoadScene(0);
        }

        public void TakeDamage(DamageInfo damageInfo)
        {
            DecreaseHealth(damageInfo.Damage);
        }
    }
}