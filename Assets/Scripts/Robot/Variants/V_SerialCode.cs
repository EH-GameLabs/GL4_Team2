using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_SerialCode : MonoBehaviour
{
    [SerializeField] private List<string> serialCodes = new List<string>();

    [Header("Debug Variables")]
    [SerializeField] private string serialCodeTmp;

    public string GetRandomSerialCode()
    {
        serialCodeTmp = serialCodes[Random.Range(0, serialCodes.Count)];
        return serialCodeTmp;
    }

    public bool ControlSerialCode(string serialCode)
    {
        return serialCodeTmp.Equals(serialCode);
    }
}
