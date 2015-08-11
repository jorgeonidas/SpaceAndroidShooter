using UnityEngine;
using System.Collections;

public class Done_RandomRotator : MonoBehaviour 
{
	public float tumble;
	
	void Start ()
	{
		//modificado para trabajar en 2d
		GetComponent<Rigidbody2D>().angularVelocity = Random.value * tumble;
	}
}