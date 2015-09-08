using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	//prefabs a spawmnear y posicion
	public GameObject [] peligros;
	//public GameObject[] powerUps;//el tamaño del array se asginara en el inspector
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
	public float esperaVictoria;
	//banderas
	bool gameOver;
	bool missionSucces;
	bool restartLevel;
	//GUI
	public Text scoreText;
	public Text scoreText1;
	public GameObject acomplishedText;
	public GameObject failText;
	public GameObject finalScore;
	public GameObject botonRestart; 
	public GameObject botonContinuar;
	public GameObject botonToMainMenu;
	public GameObject botonFire;
	public GameObject joistick;
	//pause manager para activarlo y desactivarlo
	public PauseManager pauseManager;
	//para el lvl unlocker
	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;
	//Level1.1, level1.2 y asi sucecivamente
	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevelName;//nivel actual para comparar
		Debug.Log (currentLevel);
		Debug.Log (PlayerPrefs.GetInt ("Score" + Application.loadedLevelName));
		Debug.Log ("Score" + Application.loadedLevelName);
		score = 0;
		gameOver = false;
		numOleadas = oleadas.Length;

		pauseManager.enabled = true;//pause manager funciona

		StartCoroutine (SpawnOleadas ());
		updateScore ();
		//Debug.Log (Application.loadedLevelName + "score" + PlayerPrefs.GetInt(Application.loadedLevelName + "score"));
	}
	

	IEnumerator SpawnOleadas()
	{
		yield return new WaitForSeconds (esperaInicial);//tiempo de la oleada inicial
		while (j < numOleadas && !gameOver ) {
			 //
			for (int i = 0; i < oleadas[j]; i++) {
				if(gameOver){
					botonFire.SetActive(false);
					break;
				}
				Vector3 spawnPosition = new Vector2 ( spawnValues.x,Random.Range (-spawnValues.y, spawnValues.y) );
				Quaternion spawnRotation = Quaternion.identity;//sin rotacion
				Instantiate (peligros[Mathf.Abs(Random.Range(0,peligros.Length))], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (esperaEntrePeligro);//tiempo entre asteroides
			}
			//
			j++;
			yield return new WaitForSeconds (esperaEntreOleada);//tiempo entre oleadas
		}
		//
		if (!gameOver) {
			yield return new WaitForSeconds (esperaVictoria);
			Debug.Log ("MissionSucces");//si gano
			MisionAcomplished();
			UnlockLevels ();
			saveScore();

		} else {
			Debug.Log("Mission Fail!");//si pierdo
			MissionFail();

		}
	}

	public void addsScore(int newScore){
		score += newScore;
		updateScore ();
	}
	
	void updateScore(){
		scoreText.text = score.ToString();
		scoreText1.text = score.ToString ();
	}

	public void SetGameOver(){
		gameOver = true;
	}
	public void MisionAcomplished(){
		pauseManager.enabled = false; //desabilitar pause manager 
		acomplishedText.SetActive (true);
		finalScore.SetActive(true);
		enableButtons ();
	}
	public void MissionFail(){
		pauseManager.enabled = false; //desabilitar pause manager 
		failText.SetActive (true);
		finalScore.SetActive(true);
		enableButtons ();
	}
	void enableButtons(){
		if(!gameOver)
			botonContinuar.SetActive (true);

		botonRestart.SetActive (true);
		botonToMainMenu.SetActive (true);
		botonFire.SetActive (false);
		joistick.SetActive (false);
	}

	protected void  UnlockLevels (){
		//set the playerprefs value of next level to 1 to unlock
		Debug.Log ("aca");
		for(int i = 0; i < LockLevel.worlds; i++){
			for(int j = 1; j < LockLevel.levels; j++){
				Debug.Log("Level"+(i+1).ToString() +"." +j.ToString());
				if(currentLevel == "Level"+(i+1).ToString() +"." +j.ToString()){//reviso en PlayerPref mi nivel actual y desbloque el siguiente asginando 1
					worldIndex  = (i+1);
					levelIndex  = (j+1);
					//si lvl acutual Level1.1 voy a desbloquear Level1.2
					PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString(),1);
					Debug.Log(PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString()));
					break;
				}
			}
		}
		//load the World1 level 
		//Application.LoadLevel("World1");
	}

	//salvaremos el score si es el mas alto
	void saveScore(){
		if(score >=  PlayerPrefs.GetInt("Score" + Application.loadedLevelName)){
			Debug.Log("NEW RECORD!!");
			PlayerPrefs.SetInt("Score" + Application.loadedLevelName,score);
		}
	}

}
