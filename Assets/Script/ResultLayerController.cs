using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultLayerController : MonoBehaviour {
	public Text resultCashText;

	// Use this for initialization
	void Start () {
		SetText (0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SetText(float resultCash) {
		resultCashText.text = resultCash.ToString();
	}

	public void ShowResultLayer(float resultCash) {
		this.gameObject.SetActive(true);
		SetText (resultCash);
	}

	public void HideResultLayer() {
		this.gameObject.SetActive(false);
	}

	public void OnResultButtonClicked() {
		Application.LoadLevel ("MainScene");
	}
}
