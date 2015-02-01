using UnityEngine;
using System.Collections;

public class JKFactory : MonoBehaviour {
	public Object jk1Prefab;
	public Object jk2Prefab;
	public Object jk3Prefab;

	public AudioClip spawnJkAudioClip;

	public float generateTime = 3.0f;
	private float previousGeneratedTime;
	

	// Use this for initialization
	void Start () {
		previousGeneratedTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldCreateNextEnemy()) {
			spawnJkByRandom();
		}
	}

	bool shouldCreateNextEnemy () {
		float time = Time.realtimeSinceStartup;
		if (time > previousGeneratedTime + generateTime) {
			previousGeneratedTime = time;
			return true;
		}
		return false;
	}

	private void spawnJkByRandom(){
		int randomNum = (int)(Random.value * 3.0f);
		Vector2 position = this.transform.position;

		Object spawnJkPrefab;

		if (randomNum == 0) {
			spawnJkPrefab = jk1Prefab;
		} else if (randomNum == 1) {
			spawnJkPrefab = jk2Prefab;
		} else if (randomNum == 2) {
			spawnJkPrefab = jk3Prefab;
		} else {
			spawnJkPrefab = jk1Prefab;
		}

		Instantiate (spawnJkPrefab, position, Quaternion.identity);
		PlayAudioClip (spawnJkAudioClip);
	}


	// Audio
	
	void PlayAudioClip(AudioClip clip) {  
		audio.clip = clip;
		audio.Play ();
	}
}
