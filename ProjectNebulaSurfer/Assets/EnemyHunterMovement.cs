using UnityEngine;
using System.Collections;

public class EnemyHunterMovement : MonoBehaviour {
	
	public float height = 3.2f;
	public float speedX = 3f;
	public float speedY = 2.0f;
	float timingOffset = 0f;//no entiendo D:
	public float posXini;
	float posYini;

	void Start(){
		posXini = -1 * GetComponent<Transform> ().position.x;
		posYini = GetComponent<Transform> ().position.y;
	}

	void Update()
	{
		posXini += Time.deltaTime * speedX;//x cambiando en el tiempo
		float offset = Mathf.Sin(Time.time * speedY + timingOffset) * height / 2;//oscilacion
		GetComponent<Transform>().position = new Vector3(-posXini, offset + posYini, 0);
		
	}
}
