using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : BaseUI
{
    [SerializeField] private float time;

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
