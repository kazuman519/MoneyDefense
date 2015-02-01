using UnityEngine;
using System.Collections;

public class JKController: MonoBehaviour {
	public float defaultSpeed = 1;
	public string tagDisappear = "Money10k";
	public string tagWait = "Money1k";
	public string tagWaitStrong = "Money5k";

	public AudioClip atackStealAudioClip1;
	public AudioClip atackStealAudioClip2;
	public AudioClip atackCashZeroAudioClip;

	public AudioClip getMoney1kAudioClip;
	public AudioClip getMoney5kAudioClip;
	public AudioClip getMoney10kAudioClip1;
	public AudioClip getMoney10kAudioClip2;

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

		speed = defaultSpeed + Random.value;
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
			PlayAudioClip (GetGetMoney10kAudioClipByRandom());
		} else if (c.gameObject.tag == tagWaitStrong) {
			RequestStop(0.5f);
			PlayAudioClip (getMoney5kAudioClip);
		} else if (c.gameObject.tag == tagWait) {
			RequestStop(2.0f);
			Object.Destroy(c.gameObject);
			PlayAudioClip (getMoney1kAudioClip);
		} else if (c.gameObject.tag == "PullDeposit") {

			// Audio play check

			WalletController walletController = c.gameObject.GetComponent<WalletController>();
			
			if (walletController.cash > 0) {
				PlayAudioClip(GetAtackStealAudioClipByRandom());
			} else if (walletController.cash == 0){ 
				PlayAudioClip(atackCashZeroAudioClip);
			} else {
				// TODO: play steal sound
			}
		} else {
			
		}
	}

	void OnCollisionStay2D (Collision2D c) {
		if (c.gameObject.tag == "PullDeposit") {
			
			WalletController walletController = c.gameObject.GetComponent<WalletController>();
			
			if (walletController.cash > 0) {
				isRequestLeave = true;
				walletController.cash = 0;
			} else if (walletController.cash == 0){ 
				speed = defaultSpeed * 3;
			} else {
				// TODO: play steal sound
			}
		} else {
   
		}
	}

	void RequestStop(float waitTime) {
		stopWaitTime = waitTime;
		previousStopTime = Time.realtimeSinceStartup;
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


	// Audio

	void PlayAudioClip(AudioClip clip) {  
		audio.clip = clip;
		audio.Play ();
	}

	AudioClip GetAtackStealAudioClipByRandom() {
		int randomNum = (int)(Random.value * 2);

		if(randomNum == 0){
			return atackStealAudioClip1;
		} else {
			return atackStealAudioClip2;
		}
	}

	AudioClip GetGetMoney10kAudioClipByRandom() {
		int randomNum = (int)(Random.value * 2);
		
		if(randomNum == 0){
			return getMoney10kAudioClip1;
		} else {
			return getMoney10kAudioClip2;
		}
	}
}
