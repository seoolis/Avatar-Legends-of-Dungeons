using Players;
using System.Collections;
using TMPro;
using UnityEngine;

public class HUDHandler : MonoBehaviour
{
    public static HUDHandler instance;

    [SerializeField] private TextMeshProUGUI notificationText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI elementText;

    private Player player;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        player = Player.Instance;
        player.HealthComponent.OnUpdateHealth.AddListener(PlayerHealthOnUpdate);
        player.ElementsHandler.OnSwitchElement.AddListener(UpdateElementText);

        PlayerHealthOnUpdate(player.HealthComponent.Health, player.HealthComponent.Health);
        UpdateElementText(player.ElementsHandler.Element);
    }

    public void Notification(string text)
    {
        StopCoroutine(ShowNotification(text));
        StartCoroutine(ShowNotification(text));
    }

    private IEnumerator ShowNotification(string text)
    {
        notificationText.text = text;
        yield return new WaitForSeconds(5);
        notificationText.text = string.Empty;
    }

    private void PlayerHealthOnUpdate(int oldValue, int newValue)
    {
        var maxHealth = player.HealthComponent.MaxHealth;
        healthText.text = $"Здоровье: {newValue}/{maxHealth}";
    }

    private void UpdateElementText(ElementType element)
    {
        elementText.text = $"Текущий элемент: {element}";
        elementText.color = GetElementColor(element);
    }

    private Color GetElementColor(ElementType element)
    {
        switch (element)
        {
            case ElementType.Fire:
                return new Color(1f, 0.5f, 0f); // Оранжевый
            case ElementType.Water:
                return Color.blue; // Синий
            case ElementType.Air:
                return Color.white; // Белый
            case ElementType.Earth:
                return new Color(0.5f, 0.25f, 0f); // Коричневый
            default:
                return Color.white; // Белый
        }
    }
}