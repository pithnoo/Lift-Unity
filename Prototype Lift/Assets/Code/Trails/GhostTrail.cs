using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    public Crosshair crosshair;
    // Start is called before the first frame update
    void Start()
    {
        crosshair = FindObjectOfType<Crosshair>();
    }

    // Update is called once per frame
    void Update()
    {
        if(crosshair.isRotated == true){
            transform.localScale = new Vector2(2,2);
        }
        else if(crosshair.isRotated == false){
            transform.localScale = new Vector2(-2,2);
        }
    }
}
