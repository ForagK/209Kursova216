using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image expBar;
    void Update()
    {
        healthText.text = "Health: " + PlayerStats.Instance.Health.ToString() + "/" + PlayerStats.Instance.MaxHealth.ToString();  
        levelText.text = "Level: " + PlayerStats.Instance.Level.ToString();
        expBar.fillAmount = PlayerStats.Instance.Experience / PlayerStats.Instance.ToNextLevel;
    }
}
