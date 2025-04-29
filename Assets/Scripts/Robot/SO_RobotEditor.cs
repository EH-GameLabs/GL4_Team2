using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SO_Robot))]
public class SO_RobotEditor : Editor
{
    private SerializedProperty robotVariantsProp;
    private SerializedProperty serialCodeProp;
    private SerializedProperty exoskeletonProp;
    private SerializedProperty coreControlProp;
    private SerializedProperty robotCodeProp;
    private SerializedProperty soundControlProp;
    private SerializedProperty lightingControlProp;
    private SerializedProperty endoskeletonProp;

    private void OnEnable()
    {
        // Link serialized properties
        robotVariantsProp = serializedObject.FindProperty("robotVariants");
        serialCodeProp = serializedObject.FindProperty("serialCode");
        exoskeletonProp = serializedObject.FindProperty("exoskeleton");
        coreControlProp = serializedObject.FindProperty("coreControl");
        robotCodeProp = serializedObject.FindProperty("robotCode");
        soundControlProp = serializedObject.FindProperty("soundControl");
        lightingControlProp = serializedObject.FindProperty("lightingControl");
        endoskeletonProp = serializedObject.FindProperty("endoskeleton");
    }

    public override void OnInspectorGUI()
    {
        // Pull updated values
        serializedObject.Update();

        // Draw the flag enum field
        EditorGUILayout.PropertyField(robotVariantsProp, new GUIContent("Robot Variants"));

        // Convert the intValue to the enum for flag checking
        RobotVariants variants = (RobotVariants)robotVariantsProp.intValue;

        // Conditionally draw each property based on flags
        if (variants.HasFlag(RobotVariants.SerialCode))
        {
            EditorGUILayout.PropertyField(serialCodeProp);
        }
        if (variants.HasFlag(RobotVariants.ExoSkeleton))
        {
            EditorGUILayout.PropertyField(exoskeletonProp);
        }
        if (variants.HasFlag(RobotVariants.CoreControl))
        {
            EditorGUILayout.PropertyField(coreControlProp);
        }
        if (variants.HasFlag(RobotVariants.RobotCode))
        {
            EditorGUILayout.PropertyField(robotCodeProp);
        }
        if (variants.HasFlag(RobotVariants.SoundControl))
        {
            EditorGUILayout.PropertyField(soundControlProp);
        }
        if (variants.HasFlag(RobotVariants.LightingControl))
        {
            EditorGUILayout.PropertyField(lightingControlProp);
        }
        if (variants.HasFlag(RobotVariants.Endoskeleton))
        {
            EditorGUILayout.PropertyField(endoskeletonProp);
        }

        // Apply changes
        serializedObject.ApplyModifiedProperties();
    }
}
