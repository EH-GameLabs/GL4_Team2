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
    private const string PATH = "Frasi Vocali Robot/";
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
    public void ControlAudio(PhraseType phrase)
    {
        string filePath = string.Empty;

        switch (phrase)
        {
            case PhraseType.GoodPhrase1:
                filePath = PATH + goodPhrase1;
                break;
            case PhraseType.GoodPhrase2:
                filePath = PATH + goodPhrase2;
                break;
            case PhraseType.GoodPhrase3:
                filePath = PATH + goodPhrase3;
                break;
            case PhraseType.BadPhrase1:
                filePath = PATH + badPhrase1;
                break;
            case PhraseType.BadPhrase2:
                filePath = PATH + badPhrase2;
                break;
            case PhraseType.BadPhrase3:
                filePath = PATH + badPhrase3;
                break;
        }

        SoundPlayer.Instance.PlayClip2(filePath);
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
        {
            dummyRobot.spriteRenderer.sprite = dummyRobot.frontSpriteOff;
        }
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.backEndoSprite ||
                 dummyRobot.spriteRenderer.sprite == dummyRobot.backSprite)
        {
            dummyRobot.spriteRenderer.sprite = dummyRobot.backSpriteOff;
        }
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.leftEndoSprite ||
                 dummyRobot.spriteRenderer.sprite == dummyRobot.leftSprite)
        {
            dummyRobot.spriteRenderer.sprite = dummyRobot.leftSpriteOff;
        }
        else if (dummyRobot.spriteRenderer.sprite == dummyRobot.rightEndoSprite ||
                 dummyRobot.spriteRenderer.sprite == dummyRobot.rightSprite)
        {
            dummyRobot.spriteRenderer.sprite = dummyRobot.rightSpriteOff;
        }
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

    public void DisableEndoSkeleton(DummyRobot dummyRobot)
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

    public void EnableEndoSkeleton(DummyRobot dummyRobot)
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

    internal void ControlMotherCode()
    {
        DummyRobot dummyRobot = FindAnyObjectByType<DummyRobot>();

        SetFrontSpriteActive(dummyRobot);

        dummyRobot.isMotherCodeActive = !dummyRobot.isMotherCodeActive;
        dummyRobot.motherCode.SetActive(dummyRobot.isMotherCodeActive);

        // zoom in camera
        if (dummyRobot.isMotherCodeActive)
        {
            CameraManager.Instance.ZoomInCamera();
        }
        else
        {
            CameraManager.Instance.ZoomOutCamera();
        }
    }

    private void SetFrontSpriteActive(DummyRobot dummyRobot)
    {
        if (!lightsOn)
            dummyRobot.spriteRenderer.sprite = dummyRobot.frontSpriteOff;
        else if (dummyRobot.isEndoActive)
            dummyRobot.spriteRenderer.sprite = dummyRobot.frontEndoSprite;
        else
            dummyRobot.spriteRenderer.sprite = dummyRobot.frontSprite;
    }
}
