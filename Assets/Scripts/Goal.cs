using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour{
	[Header("Set in Inspector")]           
    public GameObject     ConfettiEffect;

	void OnTriggerEnter(Collider other) {
		// when the trigger is hit by something
		// check to see if it's a Projectile 
		Vector3 currentpos;
		GameObject confettiinstance;
		Ball proj = other.GetComponent<Ball>();
		if (proj != null) {
			BigHoops.PlayerScored();
			currentpos = transform.position;
			confettiinstance = Instantiate( ConfettiEffect ) as GameObject;
			confettiinstance.transform.position = currentpos;
		}
	}
}
