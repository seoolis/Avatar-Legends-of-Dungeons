using UnityEngine;

public class DestructibleObject : MonoBehaviour, IDamageable
{
    [SerializeField] private int hitsToDestroy = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D _collider;
    private int currentHits = 0;
    private bool isDestroyed = false;

    public void TakeDamage(DamageInfo damageInfo)
    {
        if (isDestroyed)
            return;
        currentHits++;
        if (currentHits >= hitsToDestroy)
        {
            StartDestruction();
            return;
        }
            
        animator.SetTrigger("TakeDamage");
    }

    private void StartDestruction()
    {
        isDestroyed = true;
        if (animator != null)
            animator.SetTrigger("Destroy");
        else
            DestroyObject();
        _collider.enabled = false;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}