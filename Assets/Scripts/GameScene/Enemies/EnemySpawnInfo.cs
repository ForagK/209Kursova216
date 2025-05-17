using UnityEngine;

public class EnemySpawnInfo
{
    public EnemyData data;
    public GameObject prefab;
    public float spawnChance;

    public EnemySpawnInfo(EnemyData data, GameObject prefab)
    {
        this.data = data;
        this.prefab = prefab;
        this.spawnChance = data.baseSpawnChance;
    }
}
