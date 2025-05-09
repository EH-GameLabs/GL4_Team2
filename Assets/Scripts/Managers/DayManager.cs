using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

// Singleton

public class DayManager : MonoBehaviour
{
    // singleton
    public static DayManager Instance { get; private set; }

    // List of all the data of ingame days
    [SerializeField] public SO_Day[] days;
    public int currentDayIndex;
    public SO_Day currentDay;

    // internals
    private LightingManager lightingManager;
    private SoundPlayer soundPlayer;
    private RobotSpawner robotSpawner;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
    }

    private void Start()
    {
        // Reference and initialize components
        currentDayIndex = 0;
        currentDay = days[currentDayIndex];
        lightingManager = GetComponentInChildren<LightingManager>();
        soundPlayer = GetComponentInChildren<SoundPlayer>();
        robotSpawner = GetComponentInChildren<RobotSpawner>();

        lightingManager.UpdateDay(currentDay);
        soundPlayer.UpdateDay(currentDay);
        robotSpawner.LoadRobots(SelectCurrentDayRobots());
    }

    public void ChangeDay(int dayIndex)
    {
        currentDayIndex = dayIndex;
        currentDay = days[currentDayIndex];
        lightingManager.UpdateDay(currentDay);
        soundPlayer.UpdateDay(currentDay);
        robotSpawner.LoadRobots(SelectCurrentDayRobots());
    }

    public void GoToNextDay()
    {
        currentDayIndex++;
        currentDay = days[currentDayIndex];
        lightingManager.UpdateDay(currentDay);
        soundPlayer.UpdateDay(currentDay);
        robotSpawner.LoadRobots(SelectCurrentDayRobots());
        UIManager.instance.FadeTransition();
    }

    // Randomly select the robots in this day from SO list
    private GameObject[] SelectCurrentDayRobots()
    {
        // use selection sampling for random selection
        GameObject[] selectedRobots = new GameObject[currentDay.robotNumber];
        GameObject[] totalRobots = new GameObject[currentDay.robots.Length];
        Array.Copy(currentDay.robots, totalRobots, currentDay.robots.Length);
        int selectionIndex = 0;
        int i = 0;
        int probNum = currentDay.robotNumber;
        int probDen = currentDay.robots.Length;
        System.Random rng = new System.Random();
        totalRobots = totalRobots.OrderBy(x => rng.Next()).ToArray();
        while (selectionIndex < currentDay.robotNumber)
        {
            float chance = UnityEngine.Random.Range(0f, 1f);
            if (chance < (float)probNum / (float)probDen) // cast to float for real probability
            {
                selectedRobots[selectionIndex] = totalRobots[i];
                selectionIndex += 1;
                probNum -= 1;
                probDen -= 1;
            }
            else
            {
                probDen -= 1;
            }
            i += 1;
        }
        return selectedRobots;
    }
}
