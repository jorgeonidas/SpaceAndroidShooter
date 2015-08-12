using UnityEngine;
using System.Collections;

public class EnemyFiring : MonoBehaviour {

	public GameObject disparo;
	public Transform cañonPos;
	public int tiempoEntreTiros;

	void Start () {
		//InvokeRepeating ("disparar", 0f,Random.Range(1,5));
		StartCoroutine (disparar ());
	}

	IEnumerator disparar(){
		while (true) {
			Instantiate (disparo, cañonPos.position, cañonPos.rotation);
			yield return new WaitForSeconds (tiempoEntreTiros);
		}
	}
}
