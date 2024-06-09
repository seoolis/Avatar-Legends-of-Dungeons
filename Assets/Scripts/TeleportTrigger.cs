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
            HUDHandler.instance.Notification("�� ������ ��� ���� �����");
    }

    private void TeleportPlayer()
    {
        if (teleportTarget != null)
        {
            Player player = Player.Instance;
            if (player != null)
                player.transform.position = teleportTarget.position;
            else
                Debug.LogError("Player instance �� ������.", this);
        }
        
        else
            Debug.LogWarning("���� ��������� �� ��������� � ����������.", this);
    }
}