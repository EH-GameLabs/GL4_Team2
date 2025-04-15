using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_CoreControl : MonoBehaviour
{
    [Header("Debug Variables")]
    [SerializeField] private CoreControlType coreControlType;

    public CoreControlType GetCoreControlType()
    {
        coreControlType = (CoreControlType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CoreControlType)).Length);
        return coreControlType;
    }

    public bool ControlBattery(CoreControlType coreControl)
    {
        return coreControl == CoreControlType.Ok;
    }
}
