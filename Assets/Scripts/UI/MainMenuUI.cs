using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : BaseUI
{
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    public void GoToHud()
    {
        Time.timeScale = 1f;
        UIManager.instance.FadeOut();
        UIManager.instance.ShowUI(UIManager.GameUI.HUD);
        DayManager.Instance.Init();
    }

    public void GoToOptions()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Option);
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
