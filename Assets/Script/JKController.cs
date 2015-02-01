using UnityEngine;
using System.Collections;

public class JKController: MonoBehaviour {
	public float defaultSpeed = 1;
	public string tagDisappear = "Money10k";
	public string[] tagsWait = {"Money1k", "Money5k"};
	private float speed;
	private float stopWaitTime = 10f;
	private float previousStopTime;
	private bool isRequestStop;
	private bool isRequestLeave;

	// Use this for initialization
	void Start () {
		isRequestStop = false;
		isRequestLeave = false;
		previousStopTime = Time.realtimeSinceStartup;

		speed = defaultSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (isRequestLeave) {
			Leave ();
		} else if (ShouldStop()) {
			Stop ();
		} else {
			Run ();
		}
	}

	void OnCollisionEnter2D (Collision2D c) {
		if (c.gameObject.tag == tagDisappear) {
			isRequestLeave = true;
		} else if (isTagWait(c.gameObject.tag)) {
			RequestStop(5.0f);
			Object.Destroy(c.gameObject);
		}
	}

	void OnCollisionStay2D (Collision2D c) {
		if (c.gameObject.tag == "PullDeposit") {
			speed = defaultSpeed * 2;
			
			WalletController walletController = c.gameObject.GetComponent<WalletController>();
			
			if (walletController.cash > 0) {
				isRequestLeave = true;
				walletController.cash = 0;
			} else {
				// TODO: play steal sound
			}
		} else {
   
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
		if (!isRequestStop) {
			return false;
		}

		float time = Time.realtimeSinceStartup;

		if (time < previousStopTime + stopWaitTime ) {
			return true;
		}
		previousStopTime = time;
		isRequestStop = false;

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

	void Leave() {
		Vector2 velocity = this.gameObject.rigidbody2D.velocity;
		this.gameObject.rigidbody2D.velocity = new Vector2(speed, velocity.y);
	}
}
