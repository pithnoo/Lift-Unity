using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[CreateAssetMenu(fileName = "newDeadStateData", menuName = "Data/Dead Data/Base Data")]
public class D_DeadState : ScriptableObject
{
    public GameObject deathExplosion;
    public CinemachineImpulseSource source;
    public void shake(){
        source.GenerateImpulse();
    }
}
