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
			move (-speed);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			move (speed);
		}

		if (Input.touchCount > 0) {
			if (Input.GetTouch(0).position.x > Screen.width / 2) {
				move(speed);
			} else {
				move(-speed);
			}
		}
	}

	void move(float speed) {
		this.gameObject.rigidbody2D.velocity = new Vector3(speed, 0);
	}
}
