using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [SerializeField] UpgradeShop upgradeShop;
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Level { get; set; }
    public int Damage { get; set; }
    public float Experience { get; set; }
    public float ToNextLevel { get; set; }
    public float MoveSpeed { get; set; }
    public float RotateSpeed { get; set; }
    public float ShootRate { get; set; }
    public int IFrames { get; set; }
    public float IFramesTimer { get; set; }
    public void addExperience(int amount)
    {
        Experience += amount;
        if (Experience >= ToNextLevel)
        {
            levelUp();
        }
    }
    void levelUp()
    {
        Experience -= ToNextLevel;
        Level++;
        ToNextLevel *= 1.5f;
        SoundManager.Instance.PlayLevelUpSound();
        upgradeShop.ShowShop();
    }
    public void GetDamaged(int damage)
    {
        if (IFramesTimer >= IFrames)
        {
            IFramesTimer = 0;
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        GameManager.Instance.EndGame();
    }
    public void ResetStats()
    {
        MaxHealth = 5;
        Health = MaxHealth;
        IFrames = 1;
        IFramesTimer = IFrames;
        Damage = 2;
        ShootRate = 1f;
        MoveSpeed = 5;
        RotateSpeed = 10;
        Experience = 0;
        Level = 1;
        ToNextLevel = 5;
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
        ResetStats();
    }
    void Update()
    {
        if (IFramesTimer < IFrames)
        {
            IFramesTimer += Time.deltaTime;
        }
    }
}