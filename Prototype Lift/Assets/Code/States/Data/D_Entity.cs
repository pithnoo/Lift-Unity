using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float maxHealth = 30f;
    public float wallCheckDistance = 0.2f;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    public float playerCheckDistance = 3f;
    public Transform target;
}
