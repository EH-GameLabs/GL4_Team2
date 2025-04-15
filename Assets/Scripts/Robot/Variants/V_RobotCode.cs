using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_RobotCode : MonoBehaviour
{
    [SerializeField] private List<string> robotCodes = new List<string>();

    [Header("Debug Variables")]
    [SerializeField] private string robotCodeTmp;

    public string GetRandomRobotCode()
    {
        robotCodeTmp = robotCodes[Random.Range(0, robotCodes.Count)];
        return robotCodeTmp;
    }

    public bool ControlRobotCode(string robotCode)
    {
        return robotCodeTmp.Equals(robotCode);
    }
}
