using UnityEngine;
using System.Collections;

public class JKController: MonoBehaviour {
	public float speed = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.rigidbody2D.velocity = new Vector2(-speed, 0);
	}
}
