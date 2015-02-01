using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WalletController : MonoBehaviour {
	public Text text; // The object which desplay the balance of balance.
	public float cash = 0.0f; // The total price which ogisan has.

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
	}

	void UpdateText() {
		text.text = cash.ToString();
	}
}
