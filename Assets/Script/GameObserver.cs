using UnityEngine;
using System.Collections;

public class GameObserver : MonoBehaviour {
	public GameObject oyagiObject;
	public GameObject atmObject;
	public GameObject timerObject;
	public GameObject resultLayerObject;

	private WalletController walletController;
	private ATMController atmController;
	private GameTimerController timerController;
	private ResultLayerController resultLayerController;
	private float startCash = 0.0f; 
	private bool isFinished = false;

	// Use this for initialization
	void Start () {
		walletController = oyagiObject.GetComponent<WalletController>();
		atmController = atmObject.GetComponent<ATMController>();
		timerController = timerObject.GetComponent<GameTimerController>();
		resultLayerController = resultLayerObject.GetComponent<ResultLayerController>();
		startCash = atmController.cash;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isFinished) {
			if (walletController.cash + atmController.cash  <= 0f) {
				isFinished = true;
				FinishGame ();
			} else if (timerController.GetRestTime() <= 0f) {
				isFinished = true;
				FinishGame ();
			}
		}
	}

	void FinishGame() {
		float resultCash = walletController.cash + atmController.cash;
		Debug.Log ("chash " + resultCash + " " + startCash);
		resultLayerController.ShowResultLayer(resultCash, startCash);
	}
}