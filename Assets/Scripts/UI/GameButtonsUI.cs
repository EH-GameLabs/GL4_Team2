using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameButtons : MonoBehaviour
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
}
