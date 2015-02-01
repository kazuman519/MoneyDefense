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
	private float startCash = 0.0;

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
		if (walletController.cash + atmController.cash  <= 0f) {
			FinishGame ();
		} else if (timerController.GetRestTime() <= 0f) {
			FinishGame ();
		}
	}

	void FinishGame() {
		float resultCash = walletController.cash + atmController.cash;
		resultLayerController.ShowResultLayer(resultCash, startCash);
	}
}