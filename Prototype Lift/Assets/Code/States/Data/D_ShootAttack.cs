using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newShootAttackData", menuName = "Data/Attack Data/Shoot Attack Data")]
public class D_ShootAttack : ScriptableObject
{
    public GameObject projectile;
    public float moveSpeed;
}
