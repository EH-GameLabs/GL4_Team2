using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareManager : MonoBehaviour
{
    [Header("JUMPSCARE")]
    public bool isJumpScareActive = false;

    [Header("AUDIO Jump Scare")]
    [SerializeField] private float audioJumpScareDelay = 2f;

    [Header("Endoskeleton Jump Scare")]
    [SerializeField] private float EndoskeletonJumpScareDelay = 5f;
    [SerializeField] private Transform jumpScarePosition;

    [Header("Lighting Jump Scare")]
    public bool lightingJumpScareActive = false;
    [SerializeField] private float lightingJumpScareDelay = 3f;

    public static JumpScareManager Instance { get; private set; }

    private const string PATH = "Sound Game/";

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    #region AUDIO JUMP SCARE
    public void PlayAudioJumpScare()
    {
        isJumpScareActive = true;
        StartCoroutine(PlayAudioJumpScareCoroutine());
    }

    private IEnumerator PlayAudioJumpScareCoroutine()
    {
        yield return new WaitForSeconds(audioJumpScareDelay);
        SoundPlayer.Instance.PriorityPlayClip(PATH + "Jumpscare Urlo");
        Debug.Log("JumpScare1");
        isJumpScareActive = false;
    }
    #endregion

    #region ENDOSKELETON JUMP SCARE
    public void PlayEndoskeletonJumpScare(DummyRobot dummyRobot)
    {
        if (!isJumpScareActive)
        {
            isJumpScareActive = true;
            dummyRobot.spriteRenderer.enabled = false;
            return;
        }

        StartCoroutine(PlayEndoskeletonJumpScareCoroutine(dummyRobot));
    }

    private IEnumerator PlayEndoskeletonJumpScareCoroutine(DummyRobot dummyRobot)
    {
        VariantManager.Instance.EnableEndoSkeleton(dummyRobot);

        SoundPlayer.Instance.PriorityPlayClip(PATH + "Jumpscare Urlo");
        Debug.Log("JumpScare2");

        dummyRobot.spriteRenderer.enabled = true;
        Vector3 startingPos = dummyRobot.gameObject.transform.position;
        dummyRobot.gameObject.transform.position = jumpScarePosition.position;

        yield return new WaitForSeconds(2f);
        dummyRobot.gameObject.transform.position = startingPos;
        isJumpScareActive = false;
        VariantManager.Instance.DisableEndoSkeleton(dummyRobot);

    }

    #endregion

    // IDK IF THIS IS NEEDED
    public void PlayExoskeletonJumpScare()
    {
        SoundPlayer.Instance.PlayClip(PATH + "JumpScare3");
    }

    // IDK IF THIS IS NEEDED
    public void PlayCodeControlJumpScare()
    {
        SoundPlayer.Instance.PlayClip(PATH + "JumpScare4");
    }

    #region LIGHTING JUMP SCARE
    public void PlayLightingControlJumpScare(DummyRobot dummyRobot)
    {
        if (!isJumpScareActive)
        {
            isJumpScareActive = true;
            dummyRobot.spriteRenderer.enabled = false;
            return;
        }

        StartCoroutine(PlayLightingControlJumpScareCoroutine(dummyRobot));
    }

    private IEnumerator PlayLightingControlJumpScareCoroutine(DummyRobot dummyRobot)
    {
        yield return new WaitForSeconds(lightingJumpScareDelay);

        SoundPlayer.Instance.PriorityPlayClip(PATH + "Jumpscare Urlo");
        Debug.Log("JumpScare5");

        dummyRobot.spriteRenderer.enabled = true;
        Vector3 startingPos = dummyRobot.gameObject.transform.position;
        dummyRobot.gameObject.transform.position = jumpScarePosition.position;

        yield return new WaitForSeconds(2f);
        dummyRobot.gameObject.transform.position = startingPos;
        isJumpScareActive = false;
    }
    #endregion
}
