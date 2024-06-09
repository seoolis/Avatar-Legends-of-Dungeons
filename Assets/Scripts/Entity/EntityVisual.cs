using UnityEngine;

namespace Players
{
    public class EntityVisual : MonoBehaviour
    {
        private readonly int IS_RUNNING = Animator.StringToHash("IsRunning");
        private readonly int ATTACKING = Animator.StringToHash("Attack");

        [SerializeField] private Rigidbody2D rigBody;

        private Animator animator;

        private Vector3 previousPosition;

        private bool isRunning;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            isRunning = (transform.position - previousPosition).magnitude > 0.01;
            animator.SetBool(IS_RUNNING, isRunning);
            previousPosition = transform.position;
        }

        public void Attack()
        {
            animator.SetTrigger(ATTACKING);
        }
    }
};