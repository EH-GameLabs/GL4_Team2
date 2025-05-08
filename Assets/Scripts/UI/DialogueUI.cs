using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class DialogueUI : BaseUI
{
    [SerializeField] private float time;

    private void Awake()
    {
        SoundPlayer.Instance.audioPlayer.PlayOneShot(DayManager.Instance.currentDay.dayStartAudio);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetTime(float _time)
    {
        time = _time;
    }
}
