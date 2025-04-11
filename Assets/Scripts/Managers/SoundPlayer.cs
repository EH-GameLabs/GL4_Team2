using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // global switch
    public bool muteSounds = false;

    // internal variables
    private AudioClip[] scaryEffects;
    private AudioSource audioPlayer;
    private float soundTimer;
    private float soundProbability;
    private float maxSoundLength = 5f;

    private float countDown;

    void Start()
    {
        // get sound player
        audioPlayer = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!muteSounds) PickAndPlayRandomSound();
    }

    public void UpdateDay(SO_Day newDay)
    {
        scaryEffects = newDay.scaryEffects;
        soundTimer = newDay.soundTimer;
        soundProbability = newDay.soundProbability;
        countDown = soundTimer;
    }

    public void PickAndPlayRandomSound()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            float random = Random.Range(0, 100);
            if (random < soundProbability)
            {
                AudioClip sound = scaryEffects[Random.Range(0, scaryEffects.Length)];
                StartCoroutine(PlaySound(sound, maxSoundLength));
            }
            countDown = soundTimer;
        }
    }

    public IEnumerator PlaySound(AudioClip sound, float seconds)
    {
        // play sound for given timer
        audioPlayer.PlayOneShot(sound);
        yield return new WaitForSeconds(seconds);
        audioPlayer.Stop();
    }
}
