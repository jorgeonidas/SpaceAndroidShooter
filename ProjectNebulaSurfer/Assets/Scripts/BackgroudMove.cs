using UnityEngine;
using System.Collections;

public class BackgroudMove : MonoBehaviour {
	public float velocida;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = velocida * Time.time;
		rend.material.mainTextureOffset = new Vector2(0, offset);

	}
}
