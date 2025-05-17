using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] UITimer uITimer;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] UIEnd uiEnd;
    float timeLimit = 122f;
    float gameTimer;
    float spawnTimer = 28f;
    int wave = 1;
    bool gameEnded = false;
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
    }
    public void RestartGame()
    {
        PlayerStats.Instance.ResetStats();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void EndGame()
    {
        uiEnd.ShowMenu();
        MusicManager.Instance.PlayVictoryMusic();
        PlayerStats.Instance.ResetStats();
    }
    void SpawnEnemies()
    {
        int enemyCount = wave * 8;
        enemySpawner.Spawn(enemyCount);
    }
    void UpdateSpawnTimer()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 30)
        {
            SpawnEnemies();
            spawnTimer = 0;
            wave++;
        }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Resume();
        gameTimer = timeLimit;
    }
    void Update()
    {
        gameTimer -= Time.deltaTime;
        uITimer.UpdateTimerDisplay(gameTimer);
        if (gameTimer <= 0 && !gameEnded)
        {
            gameEnded = true;
            enemySpawner.SpawnBoss();
        }
        if(!gameEnded)
        {
            UpdateSpawnTimer();
        }
    }
}