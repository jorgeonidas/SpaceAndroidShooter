using UnityEngine;
using System.Collections;

public class PowerUpContact : MonoBehaviour {
	public GameObject powUpContact;
	LevelManager manager;
	public int score;
	// Use this for initialization
	void Start () {
		GameObject lvlManagerObj = GameObject.FindGameObjectWithTag ("GameController");
		manager = lvlManagerObj.GetComponent<LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Instantiate(powUpContact, transform.position, transform.rotation);
			Destroy (gameObject);
			manager.addsScore(score);
		}
	}
}
