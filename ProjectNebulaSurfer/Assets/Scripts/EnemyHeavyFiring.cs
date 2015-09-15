using UnityEngine;
using System.Collections;

public class EnemyHeavyFiring : MonoBehaviour {
	
	public GameObject disparo;
	public Transform cañonPos;
	//public int tiempoEntreTiros;
	public float maximo,minimo;

	void Start () {
		//InvokeRepeating ("disparar", 0f,Random.Range(1,5));
		//StartCoroutine (disparar ());
		Invoke ("disparar",Random.Range(1, 2));
	}
	
	void disparar(){
		//while (true) {
		float retraso = Random.Range(minimo, maximo);
			Instantiate (disparo, cañonPos.transform.position, Quaternion.identity);
			Instantiate (disparo, cañonPos.transform.position, Quaternion.Euler(Quaternion.identity.x,Quaternion.identity.y,10));
			Instantiate (disparo, cañonPos.transform.position, Quaternion.Euler(Quaternion.identity.x,Quaternion.identity.y,-10));
		Invoke("disparar", retraso);
			//yield return new WaitForSeconds (tiempoEntreTiros);
		//}
	}
}
