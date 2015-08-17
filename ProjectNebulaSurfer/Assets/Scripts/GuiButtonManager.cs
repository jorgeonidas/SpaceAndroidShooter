using UnityEngine;
using System.Collections;

public class GuiButtonManager : MonoBehaviour {
	public PauseManager pauseManager;
	public GameObject pauseMenuCanvas;
	public GameObject ConfirmDialogCanvas;
	bool quitOrRestart;

	public void OnPushRestart(){
		Application.LoadLevel (Application.loadedLevel);
	}
	//resume el juego
	public void ResumeGame(Object myObject){
		pauseManager.setPause (false);//el manager tiene que saber que el juego ya no esta pausado
		pauseManager.ResumeGame();
		pauseMenuCanvas.SetActive(false);

	}
	//activa el dialogo si vas a resetear el nivel
	public void AskForRestart(){
		quitOrRestart = true;
		pauseManager.enabled = false;
		pauseMenuCanvas.SetActive (false);
		ConfirmDialogCanvas.SetActive (true);
	}
	//activas el dialogo si vas a salir del nivel
	public void AskForQuit(){
		quitOrRestart = false;
		pauseManager.enabled = false;
		pauseMenuCanvas.SetActive (false);
		ConfirmDialogCanvas.SetActive (true);
	}
	public void OnPushYes(){
		if (quitOrRestart) {
			Application.LoadLevel (Application.loadedLevel);
		} else {
			Application.Quit();
		}
	}
	public void OnPushNo(){
		pauseManager.enabled = true;
		ConfirmDialogCanvas.SetActive (false);
		pauseMenuCanvas.SetActive (true);
	}

}
