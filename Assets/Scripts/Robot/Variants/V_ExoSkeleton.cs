using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class V_ExoSkeleton : MonoBehaviour
{
    [Header("Debug Variables")]
    [SerializeField] private ExoSkeletonType _typeTmp;

    public ExoSkeletonType GetExoSkeletonType()
    {
        _typeTmp = (ExoSkeletonType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ExoSkeletonType)).Length);
        return _typeTmp;
    }

    public bool ControlExoSkeleton(ExoSkeletonType exoSkeletonType)
    {
        return _typeTmp == exoSkeletonType;
    }
}
