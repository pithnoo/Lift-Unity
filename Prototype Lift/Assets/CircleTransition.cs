using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTransition : MonoBehaviour
{
    public int moveY;
    public float duration;
    public GameObject UI;
    
    public void StartAnimation(){
        LeanTween.moveY(UI, moveY, duration).setEase(LeanTweenType.easeInSine);
    }

    public void EndAnimation(){
        LeanTween.moveY(UI, -moveY, duration).setEase(LeanTweenType.easeInSine);
    }

    public IEnumerator LevelTransition(){
        LeanTween.moveY(UI, moveY, duration).setEase(LeanTweenType.easeInSine);
        yield return new WaitForSeconds(2);
        LeanTween.moveY(UI, -moveY, duration).setEase(LeanTweenType.easeInSine);
    }
    
}
