using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class FadeTween2 : MonoBehaviour
{
    public float delay;
    public float duration;
    public float inOpacity;
    public float outOpacity;
    public LeanTweenType tweenType;
    
    void OnEnable(){
        CanvasGroup canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        LeanTween.alphaCanvas(canvasGroup, inOpacity, duration).setDelay(delay).setEase(tweenType).setOnComplete(fadeOut);
    }

    void fadeOut(){
        CanvasGroup canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        LeanTween.alphaCanvas(canvasGroup, outOpacity, duration).setDelay(delay).setEase(tweenType);
    }
}
