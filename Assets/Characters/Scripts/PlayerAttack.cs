using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	
	private BoxCollider Collider;
	private MeshRenderer Renderer;
	private PlayerMovement Movement;
	private Vector2 Direction;
	private bool[] Keys;
	private bool debounce = false;
	private float x = 0.0f;
	private float y = 0.0f;
	// Use this for initialization
	void Start () {
		Collider = transform.Find("Hitbox").GetComponent<BoxCollider> ();
		Renderer = transform.Find("Hitbox").GetComponent<MeshRenderer> ();
		Movement = GetComponent<PlayerMovement> ();
		Direction = new Vector2(0, 0);
		Keys = Movement.keys;
		
		Collider.enabled = false;
		Renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Keys = Movement.keys;
		
		x = 0.0f;
		y = 0.0f;
		
		if (Keys[0]) {y += 1.0f;}
		if (Keys[1]) {x -= 1.0f;}
		if (Keys[2]) {y -= 1.0f;}
		if (Keys[3]) {x += 1.0f;}
		
		if(Keys[4] && !debounce) {
			StartCoroutine(DisplayHitbox());
		}
	}
	
	IEnumerator DisplayHitbox () {
		debounce = true;
		Collider.transform.localPosition = new Vector3 (x, y, 0.0f);
		Collider.enabled = true;
		Renderer.enabled = true;
		yield return new WaitForSeconds(1);
		Collider.enabled = false;
		Renderer.enabled = false;
		debounce = false;
	}
}
