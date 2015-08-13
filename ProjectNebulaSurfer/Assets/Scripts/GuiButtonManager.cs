using UnityEngine;
using System.Collections;

public class GuiButtonManager : MonoBehaviour {

	public void OnPushRestart(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
