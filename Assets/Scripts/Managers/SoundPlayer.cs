using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] scaryEffects;
    [SerializeField] private GameObject dayManager;
    private float soundTimer;
    [Range(0, 100)] private float soundProbability;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void UpdateDay(SO_Day newDay)
    {
        soundTimer = newDay.soundTimer;
        soundProbability = newDay.soundProbability;
    }
}
