using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    // Called from Animation Event at the end of the animation
    public void DestroySelf() {
        Destroy(gameObject);
    }
}