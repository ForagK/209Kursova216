using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int health;
    public int moveSpeed;
    public int damage;
    public int experience;
    public float baseSpawnChance;
}
