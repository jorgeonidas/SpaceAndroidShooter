using UnityEngine;
using System.Collections;

public class BackgroudMove : MonoBehaviour {
	public float velocida;
	public Renderer rend;
	float offset;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		offset += velocida * Time.deltaTime;
		rend.material.mainTextureOffset = new Vector2(0, offset);

	}
}
