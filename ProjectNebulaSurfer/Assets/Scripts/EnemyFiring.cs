using UnityEngine;
using System.Collections;

public class EnemyFiring : MonoBehaviour {

	public GameObject disparo;
	public Transform cañonPos;

	void Start () {
		InvokeRepeating ("disparar", 0f,Random.Range(1,2));
	}

	public void disparar(){
		Instantiate (disparo, cañonPos.position, cañonPos.rotation);
	}
}
