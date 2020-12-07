using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;
    public float playerCheckDistance = 0.5f;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}