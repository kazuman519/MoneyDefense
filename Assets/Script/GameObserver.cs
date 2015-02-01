using UnityEngine;
using System.Collections;

public class GameObserver : MonoBehaviour {
	public GameObject oyagiObject;
	public GameObject atmObject;
	public GameObject timerObject;
	public GameObject resultLayerObject;

	private WalletController walletcontroller;
	private ATMController atmController;
	private GameTimerController timerController;
	private ResultLayerController resultLayerController;

	// Use this for initialization
	void Start () {
		walletcontroller = oyagiObject.GetComponent<WalletController>();
		atmController = atmObject.GetComponent<ATMController>();
		timerController = timerObject.GetComponent<GameTimerController>();
		resultLayerController = resultLayerObject.GetComponent<ResultLayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (walletcontroller.cash + atmController.cash  <= 0f) {
			FinishGame ();
		} else if (timerController.GetRestTime() <= 0f) {
			FinishGame ();
		}
	}

	void FinishGame() {
		resultLayerController.ShowResultLayer(walletcontroller.cash + atmController.cash);
	}
}