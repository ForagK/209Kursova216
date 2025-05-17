using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected GameObject player;
    protected Rigidbody rb;
    protected Transform playerTransform;
    [SerializeField] EnemyData data;
    public EnemyData Data { get => data; }

    protected int health;
    protected int moveSpeed;
    protected int damage;
    protected int experience;
    protected float spawnChance;
    public float SpawnChance { get => spawnChance; set => spawnChance = value; }
    //public float BaseSpawnChance { get => baseSpawnChance; set => baseSpawnChance = value; }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }
    public virtual void Initialize() {
        health = data.health;
        moveSpeed = data.moveSpeed;
        damage = data.damage;
        experience = data.experience;
        spawnChance = data.baseSpawnChance;
    }
    public void GetDamaged(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        SoundManager.Instance.PlayEnemyDeathSound();
        PlayerStats.Instance.addExperience(experience);
        Destroy(gameObject);
    } 
    public void Damage()
    {
        PlayerStats.Instance.GetDamaged(damage);
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage();
        }
    }
}