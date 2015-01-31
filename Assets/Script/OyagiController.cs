using UnityEngine;
using System.Collections;

public class OyagiController: MonoBehaviour {
	public float speed = 1;
	private bool isMoving;
	private bool isMoveRight;

	// Use this for initialization
	void Start () {
		isMoving = false;
		isMoveRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector2 position = Input.mousePosition;
			isMoving = true;
			isMoveRight = (position.x > Screen.width / 2);
		} else {
			isMoving = false;
		}

		if (isMoving) {
			if (isMoveRight) {
				move (speed);
			} else {
				move (-speed);
			}
		} else {
			move (0);
		}
	}

	void move(float speed) {
		this.gameObject.rigidbody2D.velocity = new Vector3(speed, 0);
	}
}
