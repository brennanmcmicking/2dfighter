using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour {
	
	// private static PlayerMovement PMScript = GetComponent<PlayerMovement> ();
	private PlayerHandler PH;
	// Use this for initialization
	void Start () {
		PH = GameObject.Find ("Handler").GetComponent<PlayerHandler> ();
	}
	
	// If the hitbox enters a hurtbox
	void OnTriggerEnter (Collider other) {
		Rigidbody TargetRB = other.GetComponent<Rigidbody> ();
		PlayerTraits otherPT = other.GetComponent<PlayerTraits> ();
		
		if (TargetRB != null) {
			TargetRB.AddExplosionForce (800f + 10f * otherPT.Percent, transform.position, 5f);
			otherPT.Percent += 5.0f;
			PH.UpdatePercent();
		}
	}
}
