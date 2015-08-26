using UnityEngine;
using System.Collections;

public class EnemyHeavyFiring : MonoBehaviour {
	
	public GameObject disparo;
	public Transform cañonPos;
	public int tiempoEntreTiros;
	
	void Start () {
		//InvokeRepeating ("disparar", 0f,Random.Range(1,5));
		StartCoroutine (disparar ());
	}
	
	IEnumerator disparar(){
		while (true) {
			Instantiate (disparo, cañonPos.transform.position, Quaternion.identity);
			Instantiate (disparo, cañonPos.transform.position, Quaternion.Euler(Quaternion.identity.x,Quaternion.identity.y,10));
			Instantiate (disparo, cañonPos.transform.position, Quaternion.Euler(Quaternion.identity.x,Quaternion.identity.y,-10));

			yield return new WaitForSeconds (tiempoEntreTiros);
		}
	}
}
