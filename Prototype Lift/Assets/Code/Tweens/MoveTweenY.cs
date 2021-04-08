using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTweenY : MonoBehaviour
{
    public int moveY;
    public float duration;
    public float delay;
    public GameObject UI;
    public LeanTweenType tweenType;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(UI, moveY, duration).setEase(tweenType).setDelay(delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
