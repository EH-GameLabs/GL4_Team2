using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseUI : BaseUI
{
    public void GoToMainMenu()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.MainMenu);
    }
}
