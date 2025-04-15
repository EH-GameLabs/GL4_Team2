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
    Complete,
    Missing,
}
#endregion