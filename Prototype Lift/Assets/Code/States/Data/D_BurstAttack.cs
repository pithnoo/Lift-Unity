using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBurstAttackData", menuName = "Data/Attack Data/Burst Attack Data")]
public class D_BurstAttack : ScriptableObject
{
    public int numberOfProjectiles;
    public GameObject projectile;
    public float moveSpeed;
    public float radius;
}
