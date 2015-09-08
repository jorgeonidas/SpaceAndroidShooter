using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	public GameObject titleCanvas;
	public GameObject quitCanvas;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {

				Debug.Log ("estoy en inicio");
				quitCanvas.SetActive (true);
				titleCanvas.SetActive (false);

		}
	}

	public void toLevelSelect(){
		Application.LoadLevel("World1");
	}

	public void OnPushYes(){
		Application.Quit ();
	}

	public void OnPushNo(){

		if (Application.loadedLevelName == "Title") {
			titleCanvas.SetActive (true);
			quitCanvas.SetActive(false);
		}
	}
}
