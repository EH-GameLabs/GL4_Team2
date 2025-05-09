using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : BaseUI
{
    [SerializeField] private float decisionTimer = 3f;
    [SerializeField] Image motherCodeButton;
    [SerializeField] Image leftArrowButton;
    [SerializeField] Image rightArrowButton;

    public void RobotApproved()
    {
        if (RobotSpawner.Instance.robotIn || RobotSpawner.Instance.robotOut) return;
        SoundPlayer.Instance.PlayClip3("Pulsanti task");
        SoundPlayer.Instance.PriorityPlayClip("RobotAccettato");
        RobotSpawner.Instance.robotOut = true;
        bool approved = true;
        bool isFaulty = RobotSpawner.Instance.currentRobot.GetComponent<DummyRobot>().isFaulty;
        StartCoroutine(Decide(isFaulty, approved));
    }

    public void RobotRejected()
    {
        if (RobotSpawner.Instance.robotIn || RobotSpawner.Instance.robotOut) return;
        SoundPlayer.Instance.PlayClip3("Pulsanti task");
        SoundPlayer.Instance.PriorityPlayClip("RobotRifiutato");
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
            //RobotSpawner.Instance.robotIn = true;
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
        SoundPlayer.Instance.PlayClip3("Pulsanti task");
        FindAnyObjectByType<DummyRobot>().RotateToTheLeft();
    }

    public void RotateToTheRight()
    {
        SoundPlayer.Instance.PlayClip3("Pulsanti task");
        FindAnyObjectByType<DummyRobot>().RotateToTheRight();
    }

    public void ControlAudio()
    {
        SoundPlayer.Instance.PlayClip3("Pulsanti task");
        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();
        VariantManager.Instance.ControlAudio(dummyRobot.phrase);

        if (dummyRobot.jumpScareType == JumpScareType.Audio)
        {
            JumpScareManager.Instance.PlayAudioJumpScare();
        }
    }

    public void ControlLighting()
    {
        SoundPlayer.Instance.PlayClip3("Pulsanti task");
        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();

        if (dummyRobot.jumpScareType == JumpScareType.LigthingControl)
        {
            JumpScareManager.Instance.PlayLightingControlJumpScare(dummyRobot);
        }

        VariantManager.Instance.ControlLighting();
    }

    public void ControlEndoskeleton()
    {
        SoundPlayer.Instance.PlayClip3("Pulsanti task");
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
        if(motherCodeButton.color.a != 1)
        {
            motherCodeButton.color = new Color(1, 1, 1, 1);
            leftArrowButton.color = new Color(1, 1, 1, 1);
            rightArrowButton.color = new Color(1, 1, 1, 1);
        }
        else
        {
            motherCodeButton.color = new Color(1, 1, 1, 0);
            leftArrowButton.color = new Color(1, 1, 1, 0);
            rightArrowButton.color = new Color(1, 1, 1, 0);
        }

        SoundPlayer.Instance.PlayClip3("Pulsanti task");
        VariantManager.Instance.ControlMotherCode();
    }
}
