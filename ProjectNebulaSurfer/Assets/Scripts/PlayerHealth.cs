﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int hits;
	public GameObject explosion;
	private LevelManager manager;
	//public GameObject enemyExplosion;
	//escudo de energia
	public GameObject energyShield;
	private bool shielded;
	public int shieldHits;
	private int currShieldHits;
	//aoe
	PlayerMovement playerMovScript;

	void Start () {
		shielded = false;
		GameObject lvlManagerObj = GameObject.FindGameObjectWithTag ("GameController");
		manager = lvlManagerObj.GetComponent<LevelManager> ();
		playerMovScript = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "EnemyShot"){
			hits -= 1;
			playerMovScript.updateCanonCount(-1);
			Destroy (other.gameObject);
			Debug.Log(hits);
			if( hits <= 0){
				Debug.Log ("gameOver");
				manager.SetGameOver();
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		if (other.tag == "Enemy") {
			playerMovScript.updateCanonCount(-1);
			if (shielded == false){
				hits -= 1;
				if (hits <= 0) {
					playerMovScript.enabled = false;
					Debug.Log ("gameOver");
					manager.SetGameOver ();
					Instantiate (explosion, transform.position, transform.rotation);
					Destroy (gameObject);
				}
			}else{//tengo escudo activado
				currShieldHits -= 1;
				if(currShieldHits <= 0){
					shielded = false; // se desactiva el escudo
					energyShield.SetActive(false);
				}
			}
		}
		//aca detectaremos cada powerup y lo instanciaremos
		if (other.tag == "PowerUpShield") {
			energyShield.SetActive(true);
			currShieldHits = shieldHits;
			shielded = true;//el escudo esta activado
		}
		if (other.tag == "PowerUpAoe") {
			playerMovScript.AoeReady(); // activo el boton de area de efecto
		}

		if(other.tag == "PowerUpCanon"){
			playerMovScript.updateCanonCount(1);
		}

	
	}
}
