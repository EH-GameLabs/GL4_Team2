using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudUI : BaseUI
{

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            UIManager.instance.ShowUI(UIManager.GameUI.Pause);
        }
    }

    public void RotateToTheLeft()
    {
        FindAnyObjectByType<DummyRobot>().RotateToTheLeft();
    }

    public void RotateToTheRight()
    {
        FindAnyObjectByType<DummyRobot>().RotateToTheRight();
    }

    public void ControlEndoskeleton()
    {
        VariantManager.Instance.ControlEndoskeleton();
    }
}
