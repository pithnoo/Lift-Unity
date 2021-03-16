using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeTween : MonoBehaviour
{
    public float delay;
    public float duration;
    public float inOpacity;
    public float outOpacity;
    public LeanTweenType tweenType;
    public Image imageFade;
    public TMP_Text textFade;
    public GameObject test;
    
    void Start(){
        LeanTween.alpha(imageFade.rectTransform, inOpacity, 1f).setDelay(delay).setEase(tweenType).setOnComplete(fadeOut);
        LeanTween.alphaText(textFade.rectTransform, inOpacity, 1f).setDelay(delay).setEase(tweenType).setOnComplete(fadeOut);
    }

    void fadeOut(){
        LeanTween.alpha(imageFade.rectTransform, outOpacity, 1f).setDelay(delay).setEase(tweenType);
        LeanTween.alphaText(textFade.rectTransform, outOpacity, 1f).setDelay(delay).setEase(tweenType);
    }
}
