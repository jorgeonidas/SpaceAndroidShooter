using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int hits;
	public GameObject explosion;
	public GameObject powerUp;
	public int ScorePoints;
	private LevelManager manager;
	public float probability;// de 0.1 a 1
	//public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
		GameObject lvlManagerObj = GameObject.FindGameObjectWithTag ("GameController");
		manager = lvlManagerObj.GetComponent<LevelManager> (); //habilitar y deshabilitar
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "PlayerShot"){
			hits -= 1;
			Destroy (other.gameObject);
			if( hits <= 0){
				manager.addsScore(ScorePoints);
				Instantiate(explosion, transform.position, transform.rotation);
				if(Random.value < probability){//1 - probabilty = probabilidad: ejem 1 - 0.2 = 0.8
					Instantiate(powerUp,transform.position,Quaternion.identity);
				}
				Destroy (gameObject);
			}
		}
		if (other.tag == "Player") {
			hits -= 1;
			if( hits <= 0){
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		if (other.tag == "AOE") {
			manager.addsScore(ScorePoints);
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

}
