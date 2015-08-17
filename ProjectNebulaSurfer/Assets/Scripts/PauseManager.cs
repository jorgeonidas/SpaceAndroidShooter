using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {
	public bool gamePaused;
	public RectTransform joistick;
	public GameObject hudCanvas;
	public GameObject pauseCanvas;
	public Vector2 originalPos;
	//Sprite joistckSprite;
	// Use this for initialization
	void Start () {
		gamePaused = false;
		pauseCanvas.SetActive (gamePaused);
		Time.timeScale = 1;
		originalPos = joistick.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			gamePaused = !gamePaused;
			
			if(gamePaused == true){
				PauseGame();
			}
			if(gamePaused == false){
				ResumeGame();
			}
			
		}
	}

	public void setPause(bool b){
		gamePaused = b ;
	}
	//funciones para pausar y reanudar juego
	public void PauseGame(){
		Time.timeScale = 0;
		joistick.position = new Vector2(originalPos.x,-230);
		hudCanvas.SetActive(false);
		pauseCanvas.SetActive (true);
	}
	public void ResumeGame(){
		Time.timeScale = 1;
		joistick.position = originalPos;
		hudCanvas.SetActive(true);
		pauseCanvas.SetActive (false);
	}

}
