using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_SoundControl : MonoBehaviour
{
    [SerializeField] private List<AudioClip> sounds = new List<AudioClip>();

    [Header("Debug Variables")]
    [SerializeField] private AudioClip soundControl;

    public AudioClip GetSoundControl()
    {
        soundControl = sounds[Random.Range(0, sounds.Count)];
        return soundControl;
    }

    public bool ControlSound(AudioClip audioClip)
    {
        return audioClip == soundControl;
    }
}
