using System;

#region ROBOT

[Flags]
public enum RobotVariants
{
    SerialCode = 1 << 0,
    ExoSkeleton = 1 << 1,
    CoreControl = 1 << 2,
    RobotCode = 1 << 3,
    SoundControl = 1 << 4,
    LightingControl = 1 << 5,
    Endoskeleton = 1 << 6,
}

public enum ExoSkeletonType
{
    Ok,
    Defect,
    DifferentColor,
}

public enum CoreControlType
{
    Ok,
    Missing,
}

public enum EndoskeletonType
{
    Intact,
    Broken,
    Missing,
}

public enum PhraseType
{
    GoodPhrase1, GoodPhrase2, GoodPhrase3,
    BadPhrase1, BadPhrase2, BadPhrase3,
}

public enum JumpScareType
{
    None,
    Audio,
    Endoskeleton,
    NOT_WORKING_1,
    NOT_WORKING_2,
    LigthingControl,
}
#endregion