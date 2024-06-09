using Players;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 2f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [field: SerializeField] public ElementType Element { get; private set; }

    protected virtual void FixedUpdate()
    {
        Move();
        if (!spriteRenderer.isVisible)
            Destroy(gameObject);
    }

    protected virtual void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            transform.position + transform.up, Time.fixedDeltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageTaker))
        {
            var dmgInfo = new DamageInfo(damage, Element, transform.position);
            damageTaker.TakeDamage(dmgInfo);
        }

        Disable();
    }

    protected virtual void Disable()
    {
        Destroy(gameObject);
    }
}