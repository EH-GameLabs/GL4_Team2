//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Robot : MonoBehaviour
//{
//    [SerializeField] private SO_Robot sO_Robot;

//    // Variants variables
//    [HideInInspector] public string serialCode;
//    [HideInInspector] public ExoSkeletonType exoskeleton;
//    [HideInInspector] public CoreControlType coreControl;
//    [HideInInspector] public string robotCode;
//    [HideInInspector] public AudioClip soundControl;
//    [HideInInspector] public bool lightingControl;
//    [HideInInspector] public EndoskeletonType endoskeleton;

//    private void Start()
//    {
//        serialCode = null;
//        exoskeleton = ExoSkeletonType.Ok;
//        coreControl = CoreControlType.Ok;
//        robotCode = null;
//        soundControl = null;
//        lightingControl = false;
//        endoskeleton = EndoskeletonType.Intact;

//        InitializeVariants();
//    }

//    private void InitializeVariants()
//    {
//        if (sO_Robot.robotVariants.HasFlag(RobotVariants.SerialCode))
//        {
//            serialCode = VariantManager.Instance.V_SerialCode.GetRandomSerialCode();
//            Debug.Log("SerialCode: " + serialCode);
//        }
//        if (sO_Robot.robotVariants.HasFlag(RobotVariants.ExoSkeleton))
//        {
//            // Initialize Exoskeleton
//            exoskeleton = VariantManager.Instance.V_ExoSkeleton.GetExoSkeletonType();
//            Debug.Log("Exoskeleton: " + exoskeleton);
//        }
//        if (sO_Robot.robotVariants.HasFlag(RobotVariants.CoreControl))
//        {
//            // Initialize CoreControl
//            coreControl = VariantManager.Instance.V_CoreControl.GetCoreControlType();
//            Debug.Log($"CoreControl: {coreControl}");
//        }
//        if (sO_Robot.robotVariants.HasFlag(RobotVariants.RobotCode))
//        {
//            // Initialize RobotCode
//            robotCode = VariantManager.Instance.V_RobotCode.GetRandomRobotCode();
//            Debug.Log($"RobotCode: {robotCode}");

//        }
//        if (sO_Robot.robotVariants.HasFlag(RobotVariants.SoundControl))
//        {
//            // Initialize SoundControl
//            soundControl = VariantManager.Instance.V_SoundControl.GetSoundControl();
//            Debug.Log($"SoundControl: {soundControl.name}");
//        }
//        if (sO_Robot.robotVariants.HasFlag(RobotVariants.LightingControl))
//        {
//            // Initialize LightingControl
//            lightingControl = VariantManager.Instance.V_LightingControl.GetLightsControl();
//            Debug.Log($"LightingControl: {lightingControl}");
//        }
//        if (sO_Robot.robotVariants.HasFlag(RobotVariants.Endoskeleton))
//        {
//            // Initialize Endoskeleton
//            endoskeleton = VariantManager.Instance.V_Endoskeleton.GetEndoSkeletonType();
//            Debug.Log($"EndoSkeleton: {endoskeleton}");
//        }
//    }

//    #region GETTERS

//    public string GetSerialCode() { return serialCode; }
//    public ExoSkeletonType GetExoSkeletonType() { return exoskeleton; }
//    public CoreControlType GetCoreControlType() { return coreControl; }
//    public string GetRobotCode() { return robotCode; }
//    public string GetSoundControlCode() { return soundControl.name; }
//    public bool GetLightingControl() { return lightingControl; }
//    public EndoskeletonType GetEndoskeletonType() { return endoskeleton; }


//    #endregion
//}
