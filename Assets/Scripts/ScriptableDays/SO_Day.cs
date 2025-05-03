using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defines the properties of a given in-game day
[CreateAssetMenu(fileName = "Day", menuName = "GameData/Day")]
public class SO_Day : ScriptableObject
{
    [Tooltip("The list of possible robot prefabs that spawn in this day")]
    public GameObject[] robots;
    [Tooltip("Number of robots to be examined in this day (Must be less or equal the number of robots in this day)")]
    public int robotNumber;
    [Tooltip("Sound effects that play randomly during this day")]
    public AudioClip[] scaryEffects;
    [Tooltip("The time between scary ambient sound pulls in seconds")]
    public float soundTimer;
    [Tooltip("The probability of a random scary ambient sound playing every soundTimer seconds")]
    [Range(0, 100)] public float soundProbability;
    [Tooltip("The time between lights flickering event pulls in seconds")]
    public float lightFlickerTimer;
    [Tooltip("The probability of a random light flickering every lightFlickerTimer seconds")]
    [Range(0,100)] public float lightFlickerProbability;
    [Tooltip("The dialogue to show at the start of the day")]
    public string dialogue;
    [Tooltip("How long the dialogue lasts on screen in seconds")]
    public float dialogueDuration;
}
