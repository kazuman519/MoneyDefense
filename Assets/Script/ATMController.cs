using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ATMController : MonoBehaviour {
	public Text text; // The object which desplay the balance of balance.
	public float cash = 1000000.0f; // The total price which we have.
	public float depositPullPrice = 100000.0f;
	public string tagPullDeposit = "PullDeposit";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
	}

	void OnTriggerEnter2D (Collider2D c) { 
		if (c.tag == tagPullDeposit) { 
			Debug.Log ("hoge" + c.tag);
			WalletController wallet = c.GetComponent<WalletController>();
			PullDeposit (wallet);
		}
	}

	void UpdateText () {
		text.text = cash.ToString();
	}

	bool PullDeposit(WalletController wallet) {
		if (depositPullPrice <= cash) {
			audio.Play();
			wallet.cash = wallet.cash + depositPullPrice;
			cash = cash - depositPullPrice;
			return true;
		}
		return false;
	}
}
