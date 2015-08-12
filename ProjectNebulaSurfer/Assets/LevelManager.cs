using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	//prefabs a spawmnear y posicion
	public GameObject [] peligros; //el tamaño del array se asginara en el inspector
	public Vector2 spawnValues;
	//olas y sus cantidades
	public int [] oleadas; 
	private int numOleadas;
	private int randIndex;
	int j = 0;
	//score
	private int score;
	//tiempos
	public float esperaEntrePeligro;
	public float esperaInicial;
	public float esperaEntreOleada;
	//banderas
	bool gameOver;
	bool missionSucces;
	bool restartLevel;
	//canvas values
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;
		numOleadas = oleadas.Length;
		Debug.Log ("oleadas " + numOleadas);
		Debug.Log ("cantidad de prefabs " + peligros.Length);
		StartCoroutine (SpawnOleadas ());
		updateScore ();
	}
	

	IEnumerator SpawnOleadas()
	{
		yield return new WaitForSeconds (esperaInicial);//tiempo de la oleada inicial
		while (j < numOleadas && !gameOver ) {
			 //
			for (int i = 0; i < oleadas[j]; i++) {
				Vector3 spawnPosition = new Vector2 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y));
				Quaternion spawnRotation = Quaternion.identity;//sin rotacion
				Instantiate (peligros[Random.Range(0,peligros.Length)], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (esperaEntrePeligro);//tiempo entre asteroides
			}
			//
			j++;
			yield return new WaitForSeconds (esperaEntreOleada);//tiempo entre oleadas
		}
		//yield return new WaitForSeconds (oleadas [oleadas.Length-1] );
		if (!gameOver) {
			Debug.Log ("ya pasaron las oleadas");
		} else {
			Debug.Log("Mission Fail!");
		}
	}

	public void addsScore(int newScore){
		score += newScore;
		updateScore ();
	}
	
	void updateScore(){
		scoreText.text = score.ToString();
	}

	public void SetGameOver(){
		gameOver = true;
	}

}
