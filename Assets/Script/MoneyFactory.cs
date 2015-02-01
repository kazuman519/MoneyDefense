using UnityEngine;
using System.Collections;

public class MoneyFactory : MonoBehaviour {
	public Object money1kObject;
	public Object money5kObject;
	public Object money10kObject;
	private float prefabMoney1kObjectPrice = 1000.0f;
	private float prefabMoney5kObjectPrice = 5000.0f;
	private float prefabMoney10kObjectPrice = 10000.0f;

	public float positionOffset = 1;
	private float previousGeneratedTime;

	// Use this for initialization
	void Start () {
		previousGeneratedTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void createMoneyObject(Object prefab) {
		Vector2 position = this.transform.position;
		position.x = position.x + positionOffset;
		Object instance = Instantiate (prefab, position, Quaternion.identity);
	}


	public void putMoney(Object prefab, float requestPrice) {
		WalletController wallet = this.gameObject.GetComponent<WalletController>();
		float price = .0f;

		if (wallet.PullCash(requestPrice)) {
			price = prefabMoney1kObjectPrice;
		}

		if (price > .0f) {
			createMoneyObject(prefab);
		}
	}

	public void ShootMoney(Object moneyPrefab, float requestPrice) {

	}

	// ------------------------------------------------
	// on clicked methods
	// ------------------------------------------------

	public void onMoney1kButtonClicked(){
		putMoney (money1kObject, prefabMoney1kObjectPrice);
	}

	public void onMoney5kButtonClicked(){
		putMoney (money5kObject, prefabMoney5kObjectPrice);
	}

	public void onMoney10kButtonClicked(){
		putMoney (money10kObject, prefabMoney10kObjectPrice);
	}
}
