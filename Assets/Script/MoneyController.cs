using UnityEngine;
using System.Collections;

public class MoneyController : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.rigidbody2D.velocity = new Vector2(0, this.gameObject.rigidbody2D.velocity.y);
	}
}
