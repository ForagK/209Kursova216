using UnityEngine;
[CreateAssetMenu(menuName = "Upgrades/ShootRateUpgrade")]
public class ShootRateUpgrade : UpgradesBase
{
    void OnEnable()
    {
        Value = 0.1f;
        UpName = "Shoot Rate Upgrade";
        Description = $"Increase Shooting Rate by {Value}.";
    }
    public override void Apply()
    {
        if (PlayerStats.Instance.ShootRate > 0.1f) PlayerStats.Instance.ShootRate -= Value;
    }
}
