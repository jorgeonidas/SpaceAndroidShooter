using UnityEngine;
using System.Collections;

public class EnemyTracker : MonoBehaviour {
	private GameObject jugador;
	private float distancia;
	public float velPerc;
	public float maxDisX;
	Done_Mover moverScrpt;
	
	void Start () {
		jugador = GameObject.FindGameObjectWithTag ("Player");
		moverScrpt = GetComponent<Done_Mover>();
	}

	void Update () {
		Vector2 diferencia = transform.position - jugador.transform.position;

		if (Mathf.Abs( diferencia.x )< maxDisX) {//distancia solo en el eje x de ambos objetos
			Debug.Log (diferencia.x);
			Debug.Log ("enemigo cerca del player");
			//trata de ponerse a la misma posicion y del player
			transform.position = Vector2.MoveTowards(transform.position,jugador.transform.position, velPerc * Time.deltaTime );
			moverScrpt.enabled = false;
		}
		moverScrpt.enabled = true;
	}
}
