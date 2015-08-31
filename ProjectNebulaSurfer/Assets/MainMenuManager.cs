using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public GameObject startCanvas;
	public GameObject levelSelectCanvas;
	public GameObject QuitCanvas;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(startCanvas.activeSelf){
				Debug.Log ("estoy en inicio");
				QuitCanvas.SetActive(true);
				startCanvas.SetActive(false);

			}
			if(levelSelectCanvas.activeSelf){
				Debug.Log("estoy sleccion de nivel");
				startCanvas.SetActive (true);
				levelSelectCanvas.SetActive (false);
			}
		}
	}
	public void ToLeveLSelect(){
		startCanvas.SetActive (false);
		levelSelectCanvas.SetActive (true);
	}
	public void OnPushYes(){
		Application.Quit ();
	}
	public void OnPushNo(){
		QuitCanvas.SetActive(false);
		startCanvas.SetActive(true);
	}
}
