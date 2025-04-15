using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

}
