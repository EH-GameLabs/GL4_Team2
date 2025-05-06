using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudUI : BaseUI
{
    [SerializeField] private float decisionTimer = 2f;

    public void RobotApproved()
    {
        if (RobotSpawner.Instance.robotIn) return;
        RobotSpawner.Instance.robotOut = true;
        bool approved = true;
        bool isFaulty = RobotSpawner.Instance.currentRobot.GetComponent<DummyRobot>().isFaulty;
        StartCoroutine(Decide(isFaulty, approved));
    }

    public void RobotRejected()
    {
        if (RobotSpawner.Instance.robotIn) return;
        RobotSpawner.Instance.robotOut = true;
        bool approved = false;
        bool isFaulty = RobotSpawner.Instance.currentRobot.GetComponent<DummyRobot>().isFaulty;
        StartCoroutine(Decide(isFaulty, approved));
    }

    public IEnumerator Decide(bool isFaulty, bool approved)
    {
        yield return new WaitForSeconds(decisionTimer);
        if (isFaulty && approved)
        {
            GameManager.Instance.GameOverDead();
        }
        else if (!isFaulty && !approved)
        {
            GameManager.Instance.GameOverFired();
        }
        else
        {
            RobotSpawner.Instance.SpawnNextRobot();
            RobotSpawner.Instance.robotIn = true;
        }
    }

    private void Update()
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

    public void ControlAudio()
    {
        PhraseType phrase = FindAnyObjectByType<DummyRobot>().phrase;
        VariantManager.Instance.ControlAudio(phrase);
    }

    public void ControlLighting()
    {
        VariantManager.Instance.ControlLighting();
    }

    public void ControlEndoskeleton()
    {
        VariantManager.Instance.ControlEndoskeleton();
    }

    public void ControlMotherCode()
    {
        VariantManager.Instance.ControlMotherCode();
    }
}
