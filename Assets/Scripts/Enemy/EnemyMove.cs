using UnityEngine;

namespace Enemy
{
    using Players;

    public class EnemyMove : MonoBehaviour
    {
        public Vector2 Direction { get; private set; }
        
        private Transform target;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float detectionRange = 20f;

        private void Start()
        {
            target = Player.Instance.transform;
        }

        private void FixedUpdate()
        {
            Direction = target.position - transform.position;

            if (Direction.magnitude < detectionRange)
                MoveTowardsTarget(Direction);
        }

        private void MoveTowardsTarget(Vector3 direction)
        {
            direction.Normalize();
            Vector3 newPos = transform.position + direction * speed * Time.deltaTime;
            transform.position = newPos;
        }
    }
}