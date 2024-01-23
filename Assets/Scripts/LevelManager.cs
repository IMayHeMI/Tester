using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int enemiesOnLevel;

    [SerializeField] private int levelEnemyCounter;
    public int LevelEnemyCounter
    {
        get { return levelEnemyCounter;  }
        set { levelEnemyCounter = value; }
    }

    private void Update()
    {
        StopEnemySpawning();
    }

    public void StopEnemySpawning()
    {
        if (levelEnemyCounter == enemiesOnLevel)
            while (GameObject.Find("EnemySpawn").activeSelf)
               GameObject.Find("EnemySpawn").SetActive(false);
    }
}
