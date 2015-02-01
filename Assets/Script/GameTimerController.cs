using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimerController : MonoBehaviour {
	public Text text;
	public float stageTime = 60f;
	private float startTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		GetRestTime(GetRestTime());
	}

	public float GetRestTime() {
		float passedTime = Time.realtimeSinceStartup - startTime;

		if (passedTime > stageTime) {
			return 0f;
		}

		return stageTime - passedTime;
	}

	void UpdateText(float time) {
		text.text = time.ToString() + "秒";
	}
}
