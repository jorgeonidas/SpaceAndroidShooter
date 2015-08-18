using UnityEngine;
using System.Collections;

public class PowerUpContact : MonoBehaviour {
	public GameObject powUpContact;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Instantiate(powUpContact, transform.position, transform.rotation);
			//Instantiate(playerExplosion, transform.position, transform.rotation);
			//Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
