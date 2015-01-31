using UnityEngine;
using System.Collections;

public class OyagiController: MonoBehaviour {
	public float speed = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.gameObject.transform.position;

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.gameObject.rigidbody2D.velocity = new Vector2(-speed, 0);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.gameObject.rigidbody2D.velocity = new Vector3(speed, 0);
		}
	}
}
