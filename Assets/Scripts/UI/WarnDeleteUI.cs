using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnDeleteUI : BaseUI
{
    public void Back()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.MainMenu);
    }
}
