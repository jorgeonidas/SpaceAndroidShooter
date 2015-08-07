using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
using UnitySampleAssets.Utility;

public class PlayerMovement : MonoBehaviour {
	public float velocidad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		movimiento ();
	}

	public void movimiento(){
		float moveHorizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		float moveVertical = CrossPlatformInputManager.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f );
		GetComponent<Rigidbody2D>().velocity = movement * velocidad;
	}
}

