using UnityEngine;
using System.Collections;

public class ItemSpawnManager : MonoBehaviour {

	public GameObject PowerUpCañon;
	public GameObject PowerUpShield;
	public GameObject PowerUpAoe;

	private Transform enemyLastPos;

	public void GetEnemyLastPos(Transform et){
		enemyLastPos = et;
		Debug.Log ("ultima pos enemigo: " + et);
	}

	public void intantiatePowerUps(){

		//disparo mejorado
		if(Random.value > 0.85) //%15 percent chance (1-0.85 is 0.15)
		{//code here
			Instantiate (PowerUpCañon, enemyLastPos.position, Quaternion.identity);
			return;
		}
		//aoe
		if(Random.value > 0.95) //%5 percent chance (1 - 0.95 is 0.05)
		{ //code here
			Instantiate (PowerUpAoe, enemyLastPos.position, Quaternion.identity);
			return;
		}
		//escudo
		if(Random.value > 0.9) //%10 percent chance (1 - 0.9 is 0.1)
		{ //code here
			Instantiate (PowerUpShield, enemyLastPos.position, Quaternion.identity);
			return;
		}
	}
}
