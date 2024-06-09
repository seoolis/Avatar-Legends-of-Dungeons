using Players;
using UnityEngine;

public class SingleProjectileAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float attackCooldown = 2f;
    public ElementType elementType;

    public float lastAttackTime;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = Player.Instance.transform;
    }

    void Update()
    {
        if (Time.time > lastAttackTime + attackCooldown)
        {
            FireProjectile();
            lastAttackTime = Time.time;
        }
    }

    public void FireProjectile()
    {
        Vector2 direction = (playerTransform.position - firePoint.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.transform.up = direction;
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;

        var projectileScript = projectile.GetComponent<EnemyProjectile>();
        if (projectileScript != null)
            projectileScript.SetElementType(elementType);
    }
}
