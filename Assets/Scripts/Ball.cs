using UnityEngine;
using System.Collections.Generic;

public class Ball : MonoBehaviour {
    [Header("Set in Inspector")]           
    public static float     bottomY = -20f;

    void Update () {
        if ( transform.position.y < bottomY ) {                              // a
            Destroy( this.gameObject );        
        }
    }
}