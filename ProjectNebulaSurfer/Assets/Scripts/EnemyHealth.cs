using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int hits;
	public GameObject explosion;
	public int ScorePoints;
	private LevelManager manager;
	//public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
		GameObject lvlManagerObj = GameObject.FindGameObjectWithTag ("GameController");
		manager = lvlManagerObj.GetComponent<LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "PlayerShot"){
			hits -= 1;
			Destroy (other.gameObject);
			if( hits <= 0){
				manager.addsScore(ScorePoints);
				Instantiate(explosion, transform.position, transform.rotation);
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
