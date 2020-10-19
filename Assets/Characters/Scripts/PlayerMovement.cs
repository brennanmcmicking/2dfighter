using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody PlayerRB;
	private PlayerTraits pt;
	
	private bool key_W = false;
	private bool key_A = false;
	private bool key_S = false;
	private bool key_D = false;
	private bool key_Attack = false;
	public bool[] keys;
	
	private bool key_Space = false;
	private bool key_Space_Previous = false;
	private float key_Space_count = 1.0f;
	
	private float Velocity_Y = 0;
	
	
	// Use this for initialization
	void Start () {
		PlayerRB = GetComponent<Rigidbody>();
		pt = GetComponent<PlayerTraits> ();
		print(transform.position);
		Physics.gravity = new Vector3(0, pt.CharacterGravity, 0);
		keys = new bool[] {false, false, false, false, false};
	}
	
	// Update is called once per frame
	void Update () {
		Keys ();
		// Gravity ();
	}
	
	void FixedUpdate () {
		JumpHandler ();
		// Gravity ();
		Move ();
	}
	
	void Keys () {
		if (pt.PlayerNumber == 1) {
			if (Input.GetKeyDown("w")) {
				key_W = true;
			} 
			if (Input.GetKeyDown("a")) {
				key_A = true;
			} 
			if (Input.GetKeyDown("s")) {
				key_S = true;
			} 
			if (Input.GetKeyDown("d")) {
				key_D = true;
			} 
			if (Input.GetKeyDown("space")) {
				key_Space = true;
			} 
			if (Input.GetKeyDown(KeyCode.LeftControl)) {
				key_Attack = true;
			}
			
			if (Input.GetKeyUp("w")) {
				key_W = false;
			} 
			if (Input.GetKeyUp("a")) {
				key_A = false;
			} 
			if (Input.GetKeyUp("s")) {
				key_S = false;
			} 
			if (Input.GetKeyUp("d")) {
				key_D = false;
			} 
			if (Input.GetKeyUp("space")) {
				key_Space = false;
			}
			if (Input.GetKeyUp(KeyCode.LeftControl)) {
				key_Attack = false;
			}			
		} else {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				key_W = true;
			} 
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				key_A = true;
			} 
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				key_S = true;
			} 
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				key_D = true;
			} 
			if (Input.GetKeyDown(KeyCode.Keypad0)) {
				key_Space = true;
			} 
			if (Input.GetKeyDown(KeyCode.RightShift)) {
				key_Attack = true;
			}
			
			if (Input.GetKeyUp(KeyCode.UpArrow)) {
				key_W = false;
			} 
			if (Input.GetKeyUp(KeyCode.LeftArrow)) {
				key_A = false;
			} 
			if (Input.GetKeyUp(KeyCode.DownArrow)) {
				key_S = false;
			} 
			if (Input.GetKeyUp(KeyCode.RightArrow)) {
				key_D = false;
			} 
			if (Input.GetKeyUp(KeyCode.Keypad0)) {
				key_Space = false;
			}	
			if (Input.GetKeyUp(KeyCode.RightShift)) {
				key_Attack = false;
			}	
		}
		
		keys[0] = key_W;
		keys[1] = key_A;
		keys[2] = key_S;
		keys[3] = key_D;
		keys[4] = key_Attack;
		
	}
	
	void Move () {
		
		float MovementX = 0.0f;
		float MovementY = 0.0f;
		float MovementZ = 0.0f;
		
		if (key_D) {
			MovementX += 1.0f;
		} 
		if (key_A) {
			MovementX -= 1.0f;
		}
		
		Vector3 Movement = new Vector3 (MovementX, MovementY, MovementZ);
		
		PlayerRB.MovePosition(transform.position + Movement * Time.deltaTime * pt.CharacterSpeed);
	}
	
	void JumpHandler () {
		if (key_Space) {
			if (!key_Space_Previous) {
				key_Space_count = 1.0f;
			} else {
				key_Space_count += 1.0f;
			}
			key_Space_Previous = true;
		}
		
		if (!key_Space) {
			if (key_Space_Previous) {
				if (key_Space_count > 5) {
					float JumpSpeed = pt.CharacterFullHop;
					PlayerRB.velocity = new Vector3(0, JumpSpeed, 0);
				} else {
					float JumpSpeed = pt.CharacterShortHop;
					PlayerRB.velocity = new Vector3(0, JumpSpeed, 0);
				}
			}
			key_Space_Previous = false;
		}
		
		
	}
}
