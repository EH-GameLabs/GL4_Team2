using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_Endoskeleton : MonoBehaviour
{
    [Header("Debug Variables")]
    [SerializeField] private EndoskeletonType _typeTmp;

    public EndoskeletonType GetEndoSkeletonType()
    {
        _typeTmp = (EndoskeletonType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EndoskeletonType)).Length);
        return _typeTmp;
    }

    public bool ControlEndoSkeleton(EndoskeletonType exoSkeletonType)
    {
        return _typeTmp == exoSkeletonType;
    }
}
