using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int hits;
	public GameObject explosion;
	//public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "PlayerShot"){
			hits -= 1;
			if( hits <= 0){
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);
			}
		}
		if (other.tag == "Player") {
			Instantiate(explosion, transform.position, transform.rotation);
			//Instantiate(playerExplosion, transform.position, transform.rotation);
			//Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
