using UnityEngine;
using System.Collections;

public class ItemSpawnManager : MonoBehaviour {

	public GameObject PowerUpCañon;
	public GameObject PowerUpShield;
	public GameObject PowerUpAoe;

	private Transform enemyLastPos;
	/*
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	*/
	public void GetEnemyLastPos(Transform et){
		enemyLastPos = et;
		Debug.Log ("ultima pos enemigo: " + et);
	}

	public void intantiatePowerUps(){
		float probabilidad = Random.value;
		Debug.Log ("probabilidad= " + probabilidad);
		if (probabilidad <= 0.10) {
			Instantiate (PowerUpAoe, enemyLastPos.position, Quaternion.identity);
		} else {
			if (probabilidad <= 0.15) {
				Instantiate (PowerUpShield, enemyLastPos.position, Quaternion.identity);
			} else {
				if (probabilidad <= 0.20) {
					Instantiate (PowerUpCañon, enemyLastPos.position, Quaternion.identity);
				}
			}
		}
	}
}
