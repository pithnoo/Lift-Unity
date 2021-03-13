using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
    public LeanTweenType tweenType;
    public float duration;
    public UnityEvent onCompleteCallback;
    public float delay;

    public void OnEnable() {
        transform.localScale = new Vector3(0,0,0);
        LeanTween.scale(gameObject, new Vector3(1,1,1), duration).setDelay(delay).setOnComplete(OnComplete).setEase(tweenType);
    }

    public void OnComplete(){
        if(onCompleteCallback != null){
            onCompleteCallback.Invoke();
        }
    }
}
