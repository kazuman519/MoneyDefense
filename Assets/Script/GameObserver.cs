using UnityEngine;
using System.Collections;

public class GameObserver : MonoBehaviour {
	public GameObject oyagiObject;
	public GameObject timerObject;
	public GameObject resultLayerObject;

	private WalletController walletController;
	private GameTimerController timerController;
	private ResultLayerController resultLayerController;

	// Use this for initialization
	void Start () {
		walletController = oyagiObject.gameObject.GetComponent<WalletController>();
		timerController = timerObject.gameObject.GetComponent<GameTimerController>();
		resultLayerController = resultLayerObject.gameObject.GetComponent<ResultLayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (walletController.cash <= 0f) {
			FinishGame ();
		} else if (timerController.GetRestTime() <= 0f) {
			FinishGame ();
		}
	}

	void FinishGame() {
		resultLayerController.ShowResultLayer(walletController.cash);
	}
}