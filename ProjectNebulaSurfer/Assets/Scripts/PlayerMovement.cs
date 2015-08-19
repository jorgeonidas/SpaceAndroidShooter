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
	//cañomes
	public GameObject cañon;
	public GameObject cañon1;
	public GameObject cañon2;
	public GameObject cañon3;
	public GameObject disparo;
	public int canonCount;
	// Use this for initialization
	//ataque area de efecto
	private bool aoeReady;
	public GameObject aoeButton;
	public GameObject aoeVfx;
	void Start () {
		//canonCount = 4; // solo cañon disponible
		aoeReady = false;
		playerRgb = GetComponent<Rigidbody2D> ();
		//cañones desactivados
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
		//linea recta
		if (canonCount <= 1) { 
			Instantiate (disparo, cañon3.transform.position, Quaternion.identity);
		} else if (canonCount <= 3) {
			Instantiate (disparo, cañon3.transform.position, Quaternion.identity);
			Instantiate (disparo, cañon2.transform.position, Quaternion.identity);
		} else if (canonCount == 4) {
				Instantiate (disparo, cañon3.transform.position, Quaternion.identity);
				Instantiate (disparo, cañon2.transform.position, Quaternion.identity);
				Instantiate (disparo, cañon1.transform.position, Quaternion.Euler(Quaternion.identity.x,Quaternion.identity.y,10));
				Instantiate (disparo, cañon.transform.position, Quaternion.Euler(Quaternion.identity.x,Quaternion.identity.y,-10));
		}
		
	}
	public void AoeReady(){
		aoeReady = true;
		aoeButton.SetActive (true);
	}
	public void fireAoe(){
		Instantiate(aoeVfx, transform.position, transform.rotation);
		aoeReady = false;
		aoeButton.SetActive (false);
	}
	public void updateCanonCount(int c){
		canonCount += c;
		if (canonCount <= 1) {
			canonCount = 1;
		}
		if(canonCount>= 4){
			canonCount = 4;
		}
	}
}

	


