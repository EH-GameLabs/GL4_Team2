using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VariantManager : MonoBehaviour
{
    public static VariantManager Instance;

    [Header("Variants")]
    public V_SerialCode V_SerialCode;
    public V_ExoSkeleton V_ExoSkeleton;
    public V_CoreControl V_CoreControl;
    public V_RobotCode V_RobotCode;
    public V_SoundControl V_SoundControl;
    public V_LightingControl V_LightingControl;
    public V_Endoskeleton V_Endoskeleton;

    // AUDIO
    private const string PATH = "Assets\\Sounds\\Frasi Vocali Robot\\";
    public const string badPhrase1 = "Frase_Brutta_1";
    public const string badPhrase2 = "Frase_Brutta_2";
    public const string badPhrase3 = "Frase_Brutta_3";
    public const string goodPhrase1 = "Frase_Buona_1";
    public const string goodPhrase2 = "Frase_Buona_2";
    public const string goodPhrase3 = "Frase_Buona_3";

    // LIGHTING
    public bool lightsOn = true;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
        lightsOn = true;
    }

    /// <summary>
    /// Play audio clip from the path
    /// </summary>
    /// <param name="phrase"></param>
    public void ControlAudio(string phrase)
    {
        SoundPlayer.Instance.PlayClip(PATH + phrase);
    }


    public void ControlLighting()
    {
        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();
        if (lightsOn)
        {
            LightingManager.Instance.TurnOffAllLights();
            lightsOn = false;
            DisableLightingSprite(dummyRobot);
        }
        else
        {
            LightingManager.Instance.TurnOnAllLights();
            lightsOn = true;
            EnableLightingSprite(dummyRobot);
        }
    }

    private void DisableLightingSprite(DummyRobot dummyRobot)
    {
        if (dummyRobot.spriteRenderer.sprite == dummyRobot.frontEndoSprite ||
            dummyRobot.spriteRenderer.sprite == dummyRobot.frontSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.frontSpriteOff;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.backEndoSprite ||
                 dummyRobot.spriteRenderer.sprite == dummyRobot.backSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.backSpriteOff;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.leftEndoSprite ||
                 dummyRobot.spriteRenderer.sprite == dummyRobot.leftSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.leftSpriteOff;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.rightEndoSprite ||
                 dummyRobot.spriteRenderer.sprite == dummyRobot.rightSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.rightSpriteOff;
    }

    private void EnableLightingSprite(DummyRobot dummyRobot)
    {
        if (dummyRobot.spriteRenderer.sprite == dummyRobot.frontSpriteOff)
            dummyRobot.spriteRenderer.sprite = dummyRobot.isEndoActive ? dummyRobot.frontEndoSprite : dummyRobot.frontSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.backSpriteOff)
            dummyRobot.spriteRenderer.sprite = dummyRobot.isEndoActive ? dummyRobot.backEndoSprite : dummyRobot.backSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.leftSpriteOff)
            dummyRobot.spriteRenderer.sprite = dummyRobot.isEndoActive ? dummyRobot.leftEndoSprite : dummyRobot.leftSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.rightSpriteOff)
            dummyRobot.spriteRenderer.sprite = dummyRobot.isEndoActive ? dummyRobot.rightEndoSprite : dummyRobot.rightSprite;
    }

    public void ControlEndoskeleton()
    {
        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();
        if (dummyRobot.isEndoActive)
        {
            if (lightsOn)
                DisableEndoSkeleton(dummyRobot);
            dummyRobot.isEndoActive = false;
        }
        else
        {
            if (lightsOn)
                EnableEndoSkeleton(dummyRobot);
            dummyRobot.isEndoActive = true;
        }
    }

    private void DisableEndoSkeleton(DummyRobot dummyRobot)
    {
        if (dummyRobot.spriteRenderer.sprite == dummyRobot.frontEndoSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.frontSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.backEndoSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.backSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.leftEndoSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.leftSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.rightEndoSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.rightSprite;
    }

    private void EnableEndoSkeleton(DummyRobot dummyRobot)
    {
        if (dummyRobot.spriteRenderer.sprite == dummyRobot.frontSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.frontEndoSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.backSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.backEndoSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.leftSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.leftEndoSprite;
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.rightSprite)
            dummyRobot.spriteRenderer.sprite = dummyRobot.rightEndoSprite;
    }

    /// <summary>
    /// Control the mother code of the robot
    /// </summary>
    public void ControlCode(Sprite sprite)
    {

    }

}
