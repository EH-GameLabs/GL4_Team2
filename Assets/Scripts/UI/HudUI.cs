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
        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();
        VariantManager.Instance.ControlAudio(dummyRobot.phrase);

        if (dummyRobot.jumpScareType == JumpScareType.Audio)
        {
            JumpScareManager.Instance.PlayAudioJumpScare();
        }
    }

    public void ControlLighting()
    {
        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();

        if (dummyRobot.jumpScareType == JumpScareType.LigthingControl)
        {
            JumpScareManager.Instance.PlayLightingControlJumpScare(dummyRobot);
        }

        VariantManager.Instance.ControlLighting();
    }

    public void ControlEndoskeleton()
    {
        if (!CameraManager.Instance.IsMainCameraActive()) return;

        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();

        VariantManager.Instance.ControlEndoskeleton();

        if (dummyRobot.jumpScareType == JumpScareType.Endoskeleton)
        {
            JumpScareManager.Instance.PlayEndoskeletonJumpScare(dummyRobot);
        }
    }

    public void ControlMotherCode()
    {
        VariantManager.Instance.ControlMotherCode();
    }
}
