using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public void UpdateTimerDisplay(float time)
    {
        if (time < 0)
        {
            timerText.text = "00:00";
            return;
        }
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
