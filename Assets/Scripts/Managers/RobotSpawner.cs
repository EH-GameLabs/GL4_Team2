using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

// Singleton to fetch current robot for game over decision
public class RobotSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float conveyorSpeed;

    public static RobotSpawner Instance { get; private set; }

    [Header("Debug Variables")]
    [SerializeField] private List<GameObject> selectedRobots = new List<GameObject>();
    public GameObject currentRobot = null;
    public bool robotIn = false;
    public bool robotOut = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //robotIn = true;
    }

    // takes robots selected in day Manager and spawns them in order

    public void LoadRobots(GameObject[] robots)
    {
        // convert array into list to make it easier to process
        selectedRobots = robots.Cast<GameObject>().ToList();

        // pop first element from list and spawn
        SpawnNextRobot();
    }

    public void SpawnNextRobot()
    {
        if (selectedRobots.Count > 0)
        {
            // if there are stil robots, spawn next
            currentRobot = selectedRobots.First();
            selectedRobots.Remove(currentRobot);
            currentRobot = Instantiate(currentRobot, spawnPoint);
            robotIn = true;
            robotOut = false;
        }
        else if (DayManager.Instance.currentDayIndex < DayManager.Instance.days.Length - 1)
        {
            // otherwise move to next dayif there still are
            //Debug.Log("Day passed!");
            // TODO add UI for day passing

            DayManager.Instance.GoToNextDay();
            GameManager.Instance.dayReached += 1;
            GameManager.Instance.SaveDay(); //this saves the day reached by player
            robotIn = true;
            robotOut = false;
        }
        else
        {
            // Win condition
            UIManager.instance.ShowUI(UIManager.GameUI.Win);
            Debug.Log("Victory!");
        }
        
    }

    void Update()
    {
        if(robotIn) MoveRobotIntoScene();
        if(robotOut) MoveRobotOutOfScene();
    }

    public void MoveRobotIntoScene()
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

    public void MoveRobotOutOfScene()
    {
        if (currentRobot != null)
        {
            if ((currentRobot.transform.position - endPoint.position).magnitude > 0.001)
            {
                currentRobot.transform.position = Vector3.MoveTowards(currentRobot.transform.position,
                                                                    endPoint.position,
                                                                    conveyorSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(currentRobot.gameObject);
                robotOut = false;
            }
        }
        
    }

}
