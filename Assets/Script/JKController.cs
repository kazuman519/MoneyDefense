using UnityEngine;
using System.Collections;

public class JKController: MonoBehaviour {
	public float speed = 1;
	public string tagDisappear = "Money10k";
	public string[] tagsWait = {"Money1k", "Money5k"};
	private float stopWaitTime = 10f;
	private float previousStopTime;
	private bool isRequestStop;

	// Use this for initialization
	void Start () {
		isRequestStop = false;
		previousStopTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (ShouldStop()) {
			Stop ();
		} else {
			Run ();
		}
	}

	void OnCollisionEnter2D (Collision2D c) {
		if (c.gameObject.tag == tagDisappear) {
			Object.Destroy (this.gameObject);
		} else if (isTagWait(c.gameObject.tag)) {
			RequestStop(10.0f);
		}
	}

	bool isTagWait(string tag) {
		foreach (string canonicalTag in tagsWait) {
			if (tag == canonicalTag) {
				return true;
			}
		}
		return false;
	}

	void RequestStop(float waitTime) {
		stopWaitTime = waitTime;
		isRequestStop = true;
	}

	bool ShouldStop() {
		float time = Time.realtimeSinceStartup;

		if (time >= previousStopTime + stopWaitTime ) {
			previousStopTime = time;
			isRequestStop = false;
			return true;
		}

		return false;
	}

	void Run () {
		Vector2 velocity = this.gameObject.rigidbody2D.velocity;
		this.gameObject.rigidbody2D.velocity = new Vector2(-speed, velocity.y);
	}

	void Stop () {
		Vector2 velocity = this.gameObject.rigidbody2D.velocity;
		this.gameObject.rigidbody2D.velocity = new Vector2(0, velocity.y);
	}
}
