using UnityEngine;
[CreateAssetMenu(menuName = "Upgrades/DamageUpgrade")]
public class DamageUpgrade : UpgradesBase
{
    void OnEnable()
    {
        Value = 2;
        UpName = "Damage Upgrade";
        Description = $"Increase Damage by {Value}.";
    }
    public override void Apply()
    {
        PlayerStats.Instance.Damage += (int)Value;
    }
}
