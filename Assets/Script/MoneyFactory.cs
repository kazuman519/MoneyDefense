using UnityEngine;
using System.Collections;

public class MoneyFactory : MonoBehaviour {
	public string prefabMoney1kObjectName = "Prefabs/Money1kObject";
	public string prefabMoney5kObjectName = "Prefabs/Money5kObject";
	public string prefabMoney10kObjectName = "Prefabs/Money10kObject";

	public float positionOffset = 1;
	private float previousGeneratedTime;

	// Use this for initialization
	void Start () {
		previousGeneratedTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void createMoneyObject(string prefabName) {
		Vector2 position = this.transform.position;
		Object prefab = Resources.Load (prefabName);
		position.x = position.x + positionOffset;
		Object instance = Instantiate (prefab, position, Quaternion.identity);
	}

	// ------------------------------------------------
	// on clicked methods
	// ------------------------------------------------

	public void onMoney1kButtonClicked(){
 		Debug.Log ("on money1kbutton clicked");
		createMoneyObject (prefabMoney1kObjectName);
	}

	public void onMoney5kButtonClicked(){
		Debug.Log ("on money5kbutton clicked");
		createMoneyObject (prefabMoney5kObjectName);

	}

	public void onMoney10kButtonClicked(){
		Debug.Log ("on money10kbutton clicked");
		createMoneyObject (prefabMoney10kObjectName);
	}
}
