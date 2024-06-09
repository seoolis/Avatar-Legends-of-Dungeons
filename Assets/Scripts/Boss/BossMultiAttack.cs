using UnityEngine;

public class BossMultiAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackInterval = 5f;
    public int numberOfProjectiles = 8;
    public float projectileSpeed = 5f;
    public ElementType elementType;

    private float attackTimer;

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    private void Attack()
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float projectileDirX = Mathf.Sin((angle * Mathf.PI) / 180f);
            float projectileDirY = Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector2 projectileDir = new Vector2(projectileDirX, projectileDirY).normalized;
            Vector3 projectileSpawnPosition = transform.position + new Vector3(projectileDir.x, projectileDir.y, 0f);

            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.up = projectileDir;

            var projectileScript = projectile.GetComponent<EnemyProjectile>();
            if (projectileScript != null)
            {
                projectileScript.SetElementType(elementType);
                projectileScript.speed = projectileSpeed;
            }

            angle += angleStep;
        }
    }
}