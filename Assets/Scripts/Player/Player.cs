using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        public PlayerElement ElementsHandler { get; private set; }

        public PlayerHealth HealthComponent { get; private set; }

        public PlayerMovement Movement { get; private set; }

        public PlayerShooting Shoot { get; private set; }

        private void Awake()
        {
            Instance = this;
            ElementsHandler = GetComponent<PlayerElement>();
            HealthComponent = GetComponent<PlayerHealth>();
            Movement = GetComponent<PlayerMovement>();
            Shoot = GetComponent<PlayerShooting>();
        }

        public void AcquireElement(ElementType newElement)
        {
            ElementsHandler.AddElement(newElement);
        }
    }
}