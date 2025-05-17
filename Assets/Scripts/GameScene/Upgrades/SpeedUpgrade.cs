using UnityEngine;
[CreateAssetMenu(menuName = "Upgrades/SpeedUpgrade")]
public class SpeedUpgrade : UpgradesBase
{
    void OnEnable()
    {
        Value = 2;
        UpName = "Speed Upgrade";
        Description = $"Increase Speed by {Value}.";
    }
    public override void Apply()
    {
        PlayerStats.Instance.MoveSpeed += Value;
    }
}
