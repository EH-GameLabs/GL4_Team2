using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRobot : MonoBehaviour
{
    [Header("Robot Data")]
    [SerializeField] private SO_Robot SO_Robot;
    public bool isFaulty;
    public SpriteRenderer spriteRenderer;
    public PhraseType phrase;
    public JumpScareType jumpScareType;

    [Space(15)]
    [Header("Sprites")]
    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    [Header("Endoskeleton Sprites")]
    public bool isEndoActive = false;
    public Sprite frontEndoSprite;
    public Sprite backEndoSprite;
    public Sprite leftEndoSprite;
    public Sprite rightEndoSprite;

    [Header("LightsOff Sprites")]
    public Sprite frontSpriteOff;
    public Sprite backSpriteOff;
    public Sprite leftSpriteOff;
    public Sprite rightSpriteOff;

    [Header("MotherCode")]
    public bool isMotherCodeActive;
    public GameObject motherCode;

    private void Start()
    {
        isMotherCodeActive = false;
        motherCode.GetComponent<SpriteRenderer>().sortingOrder = 1;
        motherCode.SetActive(false);
    }

    public void RotateToTheRight() => Rotate(+1);
    public void RotateToTheLeft() => Rotate(-1);

    private void Rotate(int direction)
    {
        // Salvo lo stato iniziale di motherCode e lo disattivo sempre
        bool wasMotherActive = isMotherCodeActive;
        motherCode.SetActive(false);

        // Prendo la lista di sprite corretta
        Sprite[] sprites = GetCurrentSpriteArray();

        // Trovo l'indice corrente e calcolo quello successivo
        int currentIndex = Array.IndexOf(sprites, spriteRenderer.sprite);
        // se non trovato, parto da 0
        if (currentIndex < 0) currentIndex = 0;

        int nextIndex = (currentIndex + direction + sprites.Length) % sprites.Length;
        spriteRenderer.sprite = sprites[nextIndex];

        // Se torni al fronte (indice 0) e la mother era attiva, la riattivo
        if (nextIndex == 0 && wasMotherActive)
        {
            motherCode.SetActive(true);
        }
    }

    private Sprite[] GetCurrentSpriteArray()
    {
        if (!VariantManager.Instance.lightsOn)
        {
            return new[] { frontSpriteOff, rightSpriteOff, backSpriteOff, leftSpriteOff };
        }
        else if (isEndoActive)
        {
            return new[] { frontEndoSprite, rightEndoSprite, backEndoSprite, leftEndoSprite };
        }
        else
        {
            return new[] { frontSprite, rightSprite, backSprite, leftSprite };
        }
    }

    // TODO: REMOVE THIS IF NOT NEEDED
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
}
