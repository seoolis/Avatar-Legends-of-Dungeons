using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemy = 5;

    public float timeSpawn = 2f;
    private float timer;

    public float distance = 3;

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            if (GetActiveChildCount() < maxEnemy && enemyPrefab != null)
            {
                Debug.Log("Spawning enemy");
                Instantiate(enemyPrefab, Random.insideUnitCircle * distance, Quaternion.identity, transform);
            }
        }

        Debug.Log($"Current active enemy count: {GetActiveChildCount()}");
    }

    int GetActiveChildCount()
    {
        int count = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                count++;
            }
        }
        return count;
    }
}
