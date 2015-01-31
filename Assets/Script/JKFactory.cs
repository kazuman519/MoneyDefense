using UnityEngine;
using System.Collections;

public class JKFactory : MonoBehaviour {
	public string prefabName = "Prefabs/JKObject";
	public float generateTime = 3.0f;
	private float previousGeneratedTime;

	// Use this for initialization
	void Start () {
		previousGeneratedTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldCreateNextEnemy()) {
			Vector2 position = this.transform.position;

			// プレハブを取得
			Object prefab = Resources.Load (prefabName);
			// プレハブからインスタンスを生成
			Instantiate (prefab, position, Quaternion.identity);
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
}
