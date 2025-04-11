using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// possibly Singleton

public class DayManager : MonoBehaviour
{
    public SO_Day currentDay;
    // List of all the data of ingame days
    [SerializeField] private SO_Day[] days;
    [SerializeField] private LightingManager lightingManager;
    [SerializeField] private SoundPlayer soundPlayer;

    private int currentDayIndex;

    private void Awake()
    {
        currentDayIndex = 0;
        currentDay = days[currentDayIndex];
        lightingManager.UpdateDay(currentDay);
        soundPlayer.UpdateDay(currentDay);
    }

    void Update()
    {
        // TODO add random selection of robot number from current day robot list
        // TODO add condition that advances the day when player wins the level
    }

    void GoToNextDay()
    {
        currentDayIndex++;
        currentDay = days[currentDayIndex];
        lightingManager.UpdateDay(currentDay);
        soundPlayer.UpdateDay(currentDay);
    }
}
