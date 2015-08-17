using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
using UnitySampleAssets.Utility;

[System.Serializable]
public class Bordes 
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour {
	public float velocidad;
	public float inclinacion;
	public Bordes limiteMov;
	private Rigidbody2D playerRgb;
	public GameObject cañon;
	public GameObject disparo;
	// Use this for initialization
	void Start () {
		playerRgb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		movimiento ();
	}

	public void movimiento(){
		//cuando este en standalone o web player
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		if(Input.GetButtonDown("Fire1"){
			disparar();
		}
		//cuando estoy en android
		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		float moveHorizontal = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		float moveVertical = CrossPlatformInputManager.GetAxisRaw ("Vertical");
		#endif		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f );
		playerRgb.velocity = movement * velocidad;
		playerRgb.transform.position = new Vector2
			(
				Mathf.Clamp(playerRgb.transform.position.x,limiteMov.xMin, limiteMov.xMax),
		        Mathf.Clamp(playerRgb.transform.position.y, limiteMov.yMin, limiteMov.yMax)
			);
		playerRgb.transform.rotation = Quaternion.Euler(playerRgb.velocity.y * inclinacion, 0.0f, 0.0f);

	}

	public void disparar(){
		Instantiate (disparo, cañon.transform.position, Quaternion.identity);
	}

}

	


