using Players;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;

    public bool IsActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        
        if (IsActive)
            TeleportPlayer();
        else
            HUDHandler.instance.Notification("На уровне ещё есть враги");
    }

    private void TeleportPlayer()
    {
        if (teleportTarget != null)
        {
            Player player = Player.Instance;
            if (player != null)
                player.transform.position = teleportTarget.position;
            else
                Debug.LogError("Player instance не найден.", this);
        }
        
        else
            Debug.LogWarning("Цель телепорта не назначена в инспекторе.", this);
    }
}