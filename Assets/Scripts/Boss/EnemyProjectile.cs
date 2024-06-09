using Players;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] public float speed = 2f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [field: SerializeField]
    public ElementType Element { get; private set; }

    private Rigidbody2D rb;
    private Transform playerTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = Player.Instance.transform;
    }

    private void Update()
    {
        if (!spriteRenderer.isVisible)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageTaker))
        {
            var dmgInfo = new DamageInfo(damage, Element, transform.position);
            damageTaker.TakeDamage(dmgInfo);
            Destroy(gameObject);
        }
    }

    public void SetElementType(ElementType elementType)
    {
        Element = elementType;
    }
}