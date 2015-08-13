using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {
	private bool gamePaused;
	public RectTransform joistick;
	public GameObject hudCanvas;
	public Vector2 originalPos;
	//Sprite joistckSprite;
	// Use this for initialization
	void Start () {
		gamePaused = false;
		originalPos = joistick.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			gamePaused = !gamePaused;
			
			if(gamePaused == true){
				Time.timeScale = 0;
				gamePaused = true;
				//PauseMenu.SetActive(true);
				joistick.position = new Vector2(originalPos.x,-230);
				hudCanvas.SetActive(!gamePaused);

			}
			if(gamePaused == false){
				Time.timeScale = 1;
				gamePaused = false;
				//PauseMenu.SetActive(false);
				//SalirDialog.SetActive(false);
				joistick.position = originalPos;
				hudCanvas.SetActive(!gamePaused);
			}
			
		}
	}
	public void setPause(bool b){
		gamePaused = b;
	}	
}
