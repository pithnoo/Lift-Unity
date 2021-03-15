using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTween : MonoBehaviour
{
    public float delay;
    public float duration;
    public float inOpacity;
    public float outOpacity;
    public LeanTweenType tweenType;
    public Image imageFade;
    
    void Start(){
        LeanTween.alpha(imageFade.rectTransform, inOpacity, 1f).setDelay(delay).setEase(tweenType).setOnComplete(fadeOut);
        //LeanTween.alpha(imageFade2.rectTransform, inOpacity, 1f).setDelay(delay).setEase(tweenType).setOnComplete(fadeOut);
    }

    void fadeOut(){
        LeanTween.alpha(imageFade.rectTransform, outOpacity, 1f).setDelay(delay).setEase(tweenType);
        //LeanTween.alpha(imageFade2.rectTransform, outOpacity, 1f).setDelay(delay).setEase(tweenType).setOnComplete(fadeOut);
    }
}
