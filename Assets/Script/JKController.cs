using UnityEngine;
using System.Collections;

public class JKController: MonoBehaviour {
	public float speed = 1;
	public string tagDisappear = "Money10k";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = this.gameObject.rigidbody2D.velocity;
		this.gameObject.rigidbody2D.velocity = new Vector2(-speed, velocity.y);
	}
	
	void OnTriggerEnter2D (Collider2D c) {
		if (c.tag == tagDisappear) {
			Object.Destroy (this.gameObject);
		}
	}
}
