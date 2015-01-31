using UnityEngine;
using System.Collections;

public class MoneyFactory : MonoBehaviour {
	public string prefabName = "Prefabs/Money1kObject";
	public float generateTime = 2.0f;
	public float positionOffset = 10;
	private float previousGeneratedTime;

	// Use this for initialization
	void Start () {
		previousGeneratedTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldCreateNextEnemy()) {
			Vector2 position = this.transform.position;
			Object prefab = Resources.Load (prefabName);
			position.x = position.x + positionOffset;
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
