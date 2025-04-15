using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float conveyorSpeed;

    [SerializeField] private List<GameObject> selectedRobots = new List<GameObject>();
    private GameObject currentRobot = null;
    public bool robotIn = false;
    public bool robotOut = false;

    // takes robots selected in day Manager and spawns them in order

    public void LoadRobots(GameObject[] robots)
    {
        // convert array into list to make it easier to process
        selectedRobots = robots.Cast<GameObject>().ToList();

        // pop first element from list an spawn
        SpawnNextRobot();
    }

    public void SpawnNextRobot()
    {
        currentRobot = selectedRobots.First();
        selectedRobots.Remove(currentRobot);
        currentRobot = Instantiate(currentRobot, spawnPoint);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(robotIn) MoveRobotIntoScene();
        if(robotOut) MoveRobotOutOfScene();
    }

    private void MoveRobotIntoScene()
    {
        if (currentRobot != null)
        {
            if ((currentRobot.transform.position - targetPoint.position).magnitude > 0.001) {
                currentRobot.transform.position = Vector3.MoveTowards(currentRobot.transform.position,
                                                                    targetPoint.position,
                                                                    conveyorSpeed * Time.deltaTime);
            }
            else
            {
                robotIn = false;
            }
        }
    }

    private void MoveRobotOutOfScene()
    {
        if (currentRobot != null)
        {
            if ((currentRobot.transform.position - endPoint.position).magnitude > 0.001)
            {
                //Thread.Sleep(2000); // wait 2 seconds
                currentRobot.transform.position = Vector3.MoveTowards(currentRobot.transform.position,
                                                                    endPoint.position,
                                                                    conveyorSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(currentRobot.gameObject);
                SpawnNextRobot();
                robotOut = false;
                robotIn = true;
            }
        }
        
    }

}
