using UnityEngine;

public class TriggerEnabler : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SetTargetObjectActive(true);
    }

    private void SetTargetObjectActive(bool isActive)
    {
        if (targetObject != null)
            targetObject.SetActive(isActive);
        else
            Debug.LogWarning("Целевой объект не назначен в инспекторе.", this);
    }
}