using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : BaseUI
{
    public void GoToMainMenu()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.MainMenu);
    }
}
