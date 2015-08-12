using UnityEngine;
using System.Collections;

public class DestruidoAlSalir : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other){
		Destroy (other.gameObject);
	}

}
