using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public GameObject startCanvas;
	public GameObject levelSelectCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ToLeveLSelect(){
		startCanvas.SetActive (false);
		levelSelectCanvas.SetActive (true);
	}
}
