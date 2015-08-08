using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int hits;
	public GameObject explosion;
	//public GameObject enemyExplosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "EnemyShot"){
			hits -= 1;
			Destroy (other.gameObject);
			Debug.Log(hits);
			if( hits <= 0){
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		if (other.tag == "Enemy") {
			hits -= 1;
			if( hits <= 0){
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}
