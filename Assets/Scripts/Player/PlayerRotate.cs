using UnityEngine;

namespace Players
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private GameInput gameInput;
        private PlayerMovement playerMovement;

        private void Start()
        {
            gameInput = GameInput.Instance;
            playerMovement = Player.Instance.Movement;
        }

        private void Update()
        {
            AdjustPlayerFacingDirection();
        }

        private void AdjustPlayerFacingDirection()
        {
            Vector3 mousePos = gameInput.GetMousePosition();
            Vector3 playerPosition = playerMovement.GetPlayerScreenPosition();
            spriteRenderer.flipX = mousePos.x < playerPosition.x;
        }
    }
}