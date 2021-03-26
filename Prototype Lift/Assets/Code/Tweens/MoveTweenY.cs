using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTweenY : MonoBehaviour
{
    public int moveY;
    public float duration;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(UI, moveY, duration).setEase(LeanTweenType.easeInSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
