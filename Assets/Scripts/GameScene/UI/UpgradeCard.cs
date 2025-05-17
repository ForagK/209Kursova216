using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upName;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] Image icon;
    [SerializeField] Button button;
    public void Init(UpgradesBase upgrade, UpgradeShop shop)
    {
        upName.text = upgrade.UpName;
        description.text = upgrade.Description;
        icon.sprite = Resources.Load<Sprite>("Upgrades/Icons/" + upgrade.UpName);
        button.onClick.AddListener(() =>
        {
            upgrade.Apply();
            shop.HideShop();
        });
    }
}
