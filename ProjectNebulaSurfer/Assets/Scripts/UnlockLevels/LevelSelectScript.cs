﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour {
	
	private int worldIndex;   
	private int levelIndex;

	GameObject maxScoreObj;
	Text MaxScore;



	void  Start (){
		//loop thorugh all the worlds
		for(int i = 1; i <= LockLevel.worlds; i++){
			if(Application.loadedLevelName == "World"+i){
				worldIndex = i;
				CheckLockedLevels();
				checkScores();
			}
		}
	}
	
	//Level to load on button click. Will be used for Level button click event 
	public void Selectlevel(string worldLevel){
		Application.LoadLevel("Level"+worldLevel); //load the level
	}
	
	//function to check for the levels locked
	void  CheckLockedLevels (){
		//loop through the levels of a particular world
		for(int j = 1; j < LockLevel.levels; j++){
			levelIndex = (j+1);
			if((PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString()))==1){
				GameObject.Find("LockedLevel"+(j+1)).active = false;
				Debug.Log ("Unlocked");

			}
		}
	}
	void checkScores(){
		for (int i = 1; i <= LockLevel.levels; i++) {
			maxScoreObj = GameObject.Find("MaxScoreLvl"+(i));
			MaxScore = maxScoreObj.GetComponent<Text>();
			Debug.Log("ScoreLevel"+ worldIndex.ToString() +"." +i);
			Debug.Log(PlayerPrefs.GetInt("ScoreLevel"+ worldIndex.ToString() +"." +i));
			MaxScore.text = PlayerPrefs.GetInt("ScoreLevel"+ worldIndex.ToString() +"." +i.ToString()).ToString();
		}
	}
}