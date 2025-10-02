using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {
    // fields set in the Unity Inspector pane
    [Header("Set in Inspector")]                                            // a
    public GameObject          prefabProjectile;
    public float                 velocityMult = 8f;   

    // fields set dynamically
    [Header("Set Dynamically")]                                             // a
    public GameObject          launchPoint;
    public Vector3             launchPos;                                   // b
    public GameObject          projectile;                                  // b
    public bool                aimingMode;                                  // b
    private Rigidbody          projectileRigidbody;   

    void Awake() {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive( false );
        launchPos = launchPointTrans.position;                              // c
    }

    void OnMouseEnter() {
      //print("Slingshot:OnMouseEnter()");
      launchPoint.SetActive( true );
    }
    void OnMouseExit() {
      if (aimingMode) return;
      else
      {
        launchPoint.SetActive( false );
      }
      
    }

    void OnMouseDown() {                                                    // d
        // The player has pressed the mouse button while over Slingshot
        aimingMode = true;
        // Instantiate a Projectile
        projectile = Instantiate( prefabProjectile ) as GameObject;
        // Start it at the launchPoint
        projectile.transform.position = launchPos;
        // Set it to isKinematic for now
        projectileRigidbody = projectile.GetComponent<Rigidbody>();                // a
        projectileRigidbody.isKinematic = true;       
    }

    void Update() {
        // If Slingshot is not in aimingMode, don't run this code
        if (!aimingMode) return;                                                   // b

        Vector3 mousePos3D = Input.mousePosition;
        mousePos3D.z = Camera.main.WorldToScreenPoint(launchPos).z; 
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos3D);

        // Find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePosWorld-launchPos;
        // Limit mouseDelta to the radius of the Slingshot SphereCollider          // d
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        // Move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if ( Input.GetMouseButtonUp(0) ) {                                         // e
            // The mouse has been released
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.linearVelocity = -mouseDelta * velocityMult;
            projectile = null;
            if (launchPoint.activeSelf ==  true )
            {
            launchPoint.SetActive( false );
            }
        }
    }
}