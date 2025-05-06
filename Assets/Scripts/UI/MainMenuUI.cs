using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : BaseUI
{
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Start()
    {
        // Fetch which days have been unlocked and disable the ones that haven't
        int dayN = DayManager.Instance.days.Length;
        Button[] dayButtons = new Button[dayN];
        for (int i = 0; i < dayN; i++)
        {
            dayButtons[i] = transform.GetChild(i).GetComponent<Button>();
            if (i > GameManager.Instance.dayReached)
            {
                dayButtons[i].interactable = false;
            }
        }
    }

    public void GoToHud()
    {
        Time.timeScale = 1f;
        UIManager.instance.FadeOut();
        UIManager.instance.ShowUI(UIManager.GameUI.HUD);
    }

    public void GoToDay(int dayIndex)
    {
        DayManager.Instance.ChangeDay(dayIndex);
        GoToHud();
    }

    public void GoToOptions()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Option);
    }

    public void DeletSave()
    {
        GameManager.Instance.ResetDays();
        GameManager.Instance.ReloadGame();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
