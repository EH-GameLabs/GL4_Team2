using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Robot", menuName = "GameData/Robot")]
public class SO_Robot : ScriptableObject
{
    public RobotVariants robotVariants;

    [Header("Correct Robot Data")]
    public string serialCode;
    public ExoSkeletonType exoskeleton;
    public CoreControlType coreControl;
    public string robotCode;
    public AudioClip soundControl;
    public bool lightingControl;
    public EndoskeletonType endoskeleton;
}
