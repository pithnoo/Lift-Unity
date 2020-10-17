using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    Animator animator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    
    void ChangeAnimationState(string newState){
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}
