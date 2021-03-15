using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTween : MonoBehaviour
{
    public float delay;
    public float duration;
    public float opacity;
    public LeanTweenType tweenType;
    
    void Start(){
        LeanTween.alpha(gameObject, 1f, duration).setDelay(delay).setEase(tweenType);
    }
}
