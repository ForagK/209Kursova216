using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    static bool isMenuActive = false;
    public void ToggleMenu()
    {
        if (isMenuActive)
        {
            HideMenu();
        }
        else
        {
            ShowMenu();
        }
    }
    public void ShowMenu()
    {
        GameManager.Instance.Pause();
        isMenuActive = true;
        menuUI.SetActive(true);
    }
    public void HideMenu()
    {
        GameManager.Instance.Resume();
        isMenuActive = false;
        menuUI.SetActive(false);
    }
}
