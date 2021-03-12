using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTween : MonoBehaviour
{
    public float distance;
    public float duration;
    void OnEnable() {
        LeanTween.moveY(gameObject, distance, duration).setLoopPingPong();
    }
    
}
