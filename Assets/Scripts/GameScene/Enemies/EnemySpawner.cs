using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    List<EnemySpawnInfo> enemyInfos = new();
    List<Vector3> spawnerPositions = new List<Vector3>();
    void Awake()
    {
        EnemyBase[] enemyBases = Resources.LoadAll<EnemyBase>("Prefabs/Enemies");
        foreach (EnemyBase basePrefab in enemyBases)
        {
            enemyInfos.Add(new EnemySpawnInfo(basePrefab.Data, basePrefab.gameObject));
        }

        foreach (Transform spawner in transform)
        {
            spawnerPositions.Add(spawner.position);
        }
    }
    public void Spawn(int amount)
    {
        StartCoroutine(SpawnWithDelay(amount, 0.5f));
    }
    public void SpawnBoss()
    {
        BossStandart boss = Resources.Load<BossStandart>("Prefabs/Bosses/BossStandart");
        var clone = Instantiate(boss, spawnerPositions[0], Quaternion.identity);
        clone.Initialize();
        MusicManager.Instance.PlayBossMusic();
    }
    IEnumerator SpawnWithDelay(int amount, float delay)
    {
        for (int i = 0; i < amount; i++)
        {
            EnemySpawnInfo info = ChooseEnemyType();

            SpawnEnemy(info, i);

            yield return new WaitForSeconds(delay);
        }
        AdjustSpawnChances();
    }
    void AdjustSpawnChances()
    {
        foreach (var info in enemyInfos)
        {
            info.spawnChance += 10;
        }

        var basicInfo = enemyInfos.FirstOrDefault(e => e.prefab.GetComponent<EnemyBasic>());
        float totalChance = enemyInfos.Sum(e => e.spawnChance);
        basicInfo.spawnChance -= totalChance + 10 - basicInfo.spawnChance;
    }

    void SpawnEnemy(EnemySpawnInfo info, int spawnerNum)
    {
        GameObject obj = Instantiate(info.prefab, spawnerPositions[spawnerNum % spawnerPositions.Count], Quaternion.identity);
        EnemyBase enemy = obj.GetComponent<EnemyBase>();
        enemy.Initialize();
    }
    EnemySpawnInfo ChooseEnemyType()
    {
        float totalChance = enemyInfos.Sum(e => e.spawnChance);
        float randomValue = Random.Range(0f, totalChance);

        foreach (var info in enemyInfos)
        {
            if (randomValue <= info.spawnChance)
            {
                return info;
            } 
            randomValue -= info.spawnChance;
        }

        return enemyInfos[0];
    }
}