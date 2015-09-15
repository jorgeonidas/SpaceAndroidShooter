using UnityEngine;
using System.Collections;

public class EnemyFiring : MonoBehaviour {

	public GameObject disparo;
	public Transform cañonPos;
	public float maximo,minimo;

	void Start () {
		//Invoke ("disparar", 0f,Random.Range(1,5));
		Invoke ("disparar",Random.Range(1, 2));
	}

	void disparar(){
		//while (true) {
		float retraso = Random.Range(minimo, maximo);
			// do you code
		Instantiate (disparo, cañonPos.position, cañonPos.rotation);

		Invoke("disparar", retraso);
			//yield return new WaitForSeconds (tiempoEntreTiros);
		//}
	}
}
