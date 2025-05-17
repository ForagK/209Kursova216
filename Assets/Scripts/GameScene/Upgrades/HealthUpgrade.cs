using UnityEngine;
[CreateAssetMenu(menuName = "Upgrades/HealthUpgrade")]
public class HealthUpgrade : UpgradesBase
{
    void OnEnable()
    {
        Value = 5;
        UpName = "Health Upgrade";
        Description = $"Increase max health by {Value} and heal {Value} health.";
    }
    public override void Apply()
    {
        PlayerStats.Instance.MaxHealth += (int)Value;
        PlayerStats.Instance.Health += (int)Value;
    }
}
