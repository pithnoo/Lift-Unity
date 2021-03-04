using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/Player Detected State Data/Base Data")]
public class D_PlayerDetected : ScriptableObject
{
    public float followSpeed = 4f;
    public float minPauseTime = 0f;
    public float maxPauseTime = 0f;
}