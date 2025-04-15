using UnityEngine;

public class V_LightingControl : MonoBehaviour
{
    [Header("Debug Variables")]
    [SerializeField] private bool lightsOn;

    public bool GetLightsControl()
    {
        lightsOn = Random.Range(0, 2) == 0;
        return lightsOn;
    }

    public bool ControlLight(bool lights)
    {
        return lights == lightsOn;
    }
}
