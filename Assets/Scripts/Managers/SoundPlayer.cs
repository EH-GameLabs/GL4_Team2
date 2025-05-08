using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton per chiamare clip dal nome file in qualsiasi momento con PlayClip
public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance { get; private set; }

    // global switch
    public bool muteSounds = false;

    // internal variables
    private AudioClip[] scaryEffects;
    public AudioSource audioPlayer;
    public AudioSource audioPlayer2;
    public AudioSource audioPlayer3;
    public AudioSource audioPlayer4;
    public AudioSource audioPlayer5;
    private float soundTimer;
    private float soundProbability;
    private float maxSoundLength = 5f;

    private float countDown;

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

    void Start()
    {
        // get sound players
        audioPlayer = GetComponents<AudioSource>()[0];
        audioPlayer2 = GetComponents<AudioSource>()[1];
        audioPlayer3 = GetComponents<AudioSource>()[2];
        audioPlayer3 = GetComponents<AudioSource>()[3];
        audioPlayer3 = GetComponents<AudioSource>()[4];
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

    private void PickAndPlayRandomSound()
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

    private IEnumerator PlaySound(AudioClip sound, float seconds)
    {
        // play sound for given timer
        audioPlayer5.PlayOneShot(sound);
        yield return new WaitForSeconds(seconds);
        audioPlayer5.Stop();
    }

    public void PlayClip(string file_path)
    {
        if (audioPlayer.isPlaying) return;

        AudioClip clip = Resources.Load(file_path) as AudioClip;

        audioPlayer.PlayOneShot(clip);
    }

    public void PlayClip2(string file_path)
    {
        if (audioPlayer3.isPlaying) return;

        AudioClip clip = Resources.Load(file_path) as AudioClip;

        audioPlayer3.PlayOneShot(clip);
    }

    public void PlayClip3(string file_path)
    {
        if (audioPlayer4.isPlaying) audioPlayer4.Stop();

        AudioClip clip = Resources.Load(file_path) as AudioClip;

        audioPlayer4.PlayOneShot(clip);
    }

    public void PriorityPlayClip(string file_path)
    {
        if (audioPlayer2.isPlaying)
        {
            audioPlayer.Stop();
            audioPlayer2.Stop();
        }
        AudioClip clip = Resources.Load(file_path) as AudioClip;

        audioPlayer2.PlayOneShot(clip);
    }
}
