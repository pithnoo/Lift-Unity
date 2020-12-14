using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAttackStateData", menuName = "Data/Attack Data/Base Data")]
public class D_AttackState : ScriptableObject
{
    public float attackSpeed = 5f;
    public float damage;
}
