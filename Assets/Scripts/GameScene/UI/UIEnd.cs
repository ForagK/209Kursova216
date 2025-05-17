using TMPro;
using UnityEditor;
using UnityEngine;

public class UIEnd : MonoBehaviour
{
    [SerializeField] GameObject endUI;
    [SerializeField] TextMeshProUGUI endText;
    public void ShowMenu()
    {
        GameManager.Instance.Pause();
        endUI.SetActive(true);
    }
}
