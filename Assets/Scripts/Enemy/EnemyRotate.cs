using UnityEngine;

namespace Enemy
{
    public class EnemyRotate : MonoBehaviour
    {
        [SerializeField] private EnemyMove enemyMove;
        [SerializeField] private Rigidbody2D rigBody;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            if (enemyMove == null)
                enemyMove = GetComponent<EnemyMove>();
        }

        private void FixedUpdate()
        {
            bool isRight = enemyMove.Direction.x >= 0;
            spriteRenderer.flipX = !isRight;
        }
    }
}