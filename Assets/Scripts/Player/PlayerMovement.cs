using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rigBody;
    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    private PlayerDodge playerDodge;

    private void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
        playerDodge = GetComponent<PlayerDodge>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (playerDodge != null && playerDodge.IsDodging())
            return;

        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        rigBody.MovePosition(rigBody.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        isRunning = inputVector.magnitude > minMovingSpeed;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}