using Players;
using System.Collections;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    private bool isDodging = false;
    private float dodgeDuration = 0.3f;
    private float dodgeCooldown = 3f;
    private float lastDodgeTime = -3f;

    private GameInput gameInput;
    private Rigidbody2D rigBody;
    private Collider2D playerCollider;
    private GameObject dodgeEffect;
    private PlayerHealth playerHealth;

    [SerializeField] private float dodgeSpeed = 20f;
    [SerializeField] private Sprite dodgeSprite;

    private SpriteRenderer dodgeSpriteRenderer;

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        rigBody = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        playerCollider = GetComponent<Collider2D>();
        gameInput = GameInput.Instance;

        CreateDodgeEffect();
    }

    private void CreateDodgeEffect()
    {
        dodgeEffect = new GameObject("DodgeEffect", typeof(SpriteRenderer));
        dodgeSpriteRenderer = dodgeEffect.GetComponent<SpriteRenderer>();
        dodgeSpriteRenderer.sprite = dodgeSprite;
        dodgeEffect.transform.SetParent(transform);
        dodgeEffect.transform.localPosition = Vector3.zero;
        dodgeEffect.SetActive(false);
    }

    private void Update()
    {
        if (CanDodge() && Input.GetKeyDown(KeyCode.LeftShift))
            StartCoroutine(Dodge());
    }

    private bool CanDodge()
    {
        return !isDodging && Time.time > lastDodgeTime + dodgeCooldown;
    }

    private IEnumerator Dodge()
    {
        isDodging = true;
        lastDodgeTime = Time.time;

        playerHealth.Invincibility = true;
        dodgeEffect.SetActive(true);

        Vector2 dodgeDirection = gameInput.GetMovementVector().normalized;
        rigBody.velocity = dodgeDirection * dodgeSpeed;

        dodgeSpriteRenderer.flipX = dodgeDirection.x < 0;

        yield return new WaitForSeconds(dodgeDuration);

        playerHealth.Invincibility = false;
        dodgeEffect.SetActive(false);

        rigBody.velocity = Vector2.zero;

        isDodging = false;
    }

    public bool IsDodging()
    {
        return isDodging;
    }
}