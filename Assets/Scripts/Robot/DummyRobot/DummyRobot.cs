using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRobot : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] public Sprite frontSprite;
    [SerializeField] public Sprite backSprite;
    [SerializeField] public Sprite leftSprite;
    [SerializeField] public Sprite rightSprite;

    [Header("Endoskeleton Sprites")]
    public bool isEndoActive = false;
    [SerializeField] public Sprite frontEndoSprite;
    [SerializeField] public Sprite backEndoSprite;
    [SerializeField] public Sprite leftEndoSprite;
    [SerializeField] public Sprite rightEndoSprite;

    [Header("Robot Data")]
    [SerializeField] private SO_Robot SO_Robot;
    [SerializeField] public bool isFaulty;
    [SerializeField] public SpriteRenderer spriteRenderer;

    #region RANDOMIZED VARIABLES
    //// Variants variables --> TODO: REMOVE THIS AND USE SO_Robot
    //[HideInInspector] public string serialCode;
    //[HideInInspector] public ExoSkeletonType exoskeleton;
    //[HideInInspector] public CoreControlType coreControl;
    //[HideInInspector] public string robotCode;
    //[HideInInspector] public AudioClip soundControl;
    //[HideInInspector] public bool lightingControl;
    //[HideInInspector] public EndoskeletonType endoskeleton;

    //private void Start()
    //{
    //    serialCode = null;
    //    exoskeleton = ExoSkeletonType.Ok;
    //    coreControl = CoreControlType.Ok;
    //    robotCode = null;
    //    soundControl = null;
    //    lightingControl = false;
    //    endoskeleton = EndoskeletonType.Intact;

    //    InitializeVariants();
    //}

    //private void InitializeVariants()
    //{
    //    if (SO_Robot.robotVariants.HasFlag(RobotVariants.SerialCode))
    //    {
    //        serialCode = VariantManager.Instance.V_SerialCode.GetRandomSerialCode();
    //        Debug.Log("SerialCode: " + serialCode);
    //    }
    //    if (SO_Robot.robotVariants.HasFlag(RobotVariants.ExoSkeleton))
    //    {
    //        // Initialize Exoskeleton
    //        exoskeleton = VariantManager.Instance.V_ExoSkeleton.GetExoSkeletonType();
    //        Debug.Log("Exoskeleton: " + exoskeleton);
    //    }
    //    if (SO_Robot.robotVariants.HasFlag(RobotVariants.CoreControl))
    //    {
    //        // Initialize CoreControl
    //        coreControl = VariantManager.Instance.V_CoreControl.GetCoreControlType();
    //        Debug.Log($"CoreControl: {coreControl}");
    //    }
    //    if (SO_Robot.robotVariants.HasFlag(RobotVariants.RobotCode))
    //    {
    //        // Initialize RobotCode
    //        robotCode = VariantManager.Instance.V_RobotCode.GetRandomRobotCode();
    //        Debug.Log($"RobotCode: {robotCode}");

    //    }
    //    if (SO_Robot.robotVariants.HasFlag(RobotVariants.SoundControl))
    //    {
    //        // Initialize SoundControl
    //        soundControl = VariantManager.Instance.V_SoundControl.GetSoundControl();
    //        Debug.Log($"SoundControl: {soundControl.name}");
    //    }
    //    if (SO_Robot.robotVariants.HasFlag(RobotVariants.LightingControl))
    //    {
    //        // Initialize LightingControl
    //        lightingControl = VariantManager.Instance.V_LightingControl.GetLightsControl();
    //        Debug.Log($"LightingControl: {lightingControl}");
    //    }
    //    if (SO_Robot.robotVariants.HasFlag(RobotVariants.Endoskeleton))
    //    {
    //        // Initialize Endoskeleton
    //        endoskeleton = VariantManager.Instance.V_Endoskeleton.GetEndoSkeletonType();
    //        Debug.Log($"EndoSkeleton: {endoskeleton}");
    //    }
    //}

    //#region GETTERS
    //public string GetSerialCode() { return serialCode; }
    //public ExoSkeletonType GetExoSkeletonType() { return exoskeleton; }
    //public CoreControlType GetCoreControlType() { return coreControl; }
    //public string GetRobotCode() { return robotCode; }
    //public string GetSoundControlCode() { return soundControl.name; }
    //public bool GetLightingControl() { return lightingControl; }
    //public EndoskeletonType GetEndoskeletonType() { return endoskeleton; }
    //#endregion
    #endregion  

    public void RotateToTheRight()
    {
        if (!VariantManager.Instance.lightsOn)
        {
            // lights off variant
        }
        else if (isEndoActive)
        {
            // endoskeleton variant
            if (spriteRenderer.sprite == frontEndoSprite)
                spriteRenderer.sprite = rightEndoSprite;
            else if (spriteRenderer.sprite == rightEndoSprite)
                spriteRenderer.sprite = backEndoSprite;
            else if (spriteRenderer.sprite == backEndoSprite)
                spriteRenderer.sprite = leftEndoSprite;
            else
                spriteRenderer.sprite = frontEndoSprite;
        }
        else
        {
            // normal variant
            if (spriteRenderer.sprite == frontSprite)
                spriteRenderer.sprite = rightSprite;
            else if (spriteRenderer.sprite == rightSprite)
                spriteRenderer.sprite = backSprite;
            else if (spriteRenderer.sprite == backSprite)
                spriteRenderer.sprite = leftSprite;
            else
                spriteRenderer.sprite = frontSprite;
        }
    }

    public void RotateToTheLeft()
    {
        if (!VariantManager.Instance.lightsOn)
        {
            // lights off variant
        }
        else if (isEndoActive)
        {
            // endoskeleton variant
            if (spriteRenderer.sprite == frontEndoSprite)
                spriteRenderer.sprite = leftEndoSprite;
            else if (spriteRenderer.sprite == leftEndoSprite)
                spriteRenderer.sprite = backEndoSprite;
            else if (spriteRenderer.sprite == backEndoSprite)
                spriteRenderer.sprite = rightEndoSprite;
            else
                spriteRenderer.sprite = frontEndoSprite;
        }
        else
        {
            // normal variant
            if (spriteRenderer.sprite == frontSprite)
                spriteRenderer.sprite = leftSprite;
            else if (spriteRenderer.sprite == leftSprite)
                spriteRenderer.sprite = backSprite;
            else if (spriteRenderer.sprite == backSprite)
                spriteRenderer.sprite = rightSprite;
            else
                spriteRenderer.sprite = frontSprite;
        }
    }
}
