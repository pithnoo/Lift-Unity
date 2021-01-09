using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    public Crosshair crosshair;
    public float activeTime;
    private float tempActiveTime;

    // Start is called before the first frame update
    void Start()
    {
        tempActiveTime = activeTime;
        crosshair = FindObjectOfType<Crosshair>();

        if(crosshair.isRotated){
            transform.localScale = new Vector2(2,2);
        }
        else{
            transform.localScale = new Vector2(-2,2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        tempActiveTime -= Time.deltaTime;

        if(tempActiveTime <= 0f){
            gameObject.SetActive(false);
            tempActiveTime = activeTime;
        }
    }
}
