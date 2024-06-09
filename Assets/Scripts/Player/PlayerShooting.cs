using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private ElementProjectiles elementProjectiles;
        [SerializeField] private PlayerElement playerElement;

        private Camera mainCamera;
        private GameInput gameInput;

        private void Start()
        {
            gameInput = GameInput.Instance;
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!PauseMenu.isPaused && Input.GetMouseButtonDown(0))
                Shoot();
        }

        public void Shoot()
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = ((Vector2)(mousePos - transform.position)).normalized;
            Instantiate(elementProjectiles.GetProjectile(playerElement.Element), transform.position + (Vector3)direction, Quaternion.identity).transform.up = direction;
        }
    }
}