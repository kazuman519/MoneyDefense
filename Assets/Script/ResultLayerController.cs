using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultLayerController : MonoBehaviour {
	public Text resultCashText;
	public AudioClip audioClipResultFail;
	public AudioClip audioClipResultOK;
	public AudioClip audioClipResultGood;
	public AudioClip audioClipResultGreat;
	public AudioClip audioClipResultPerfect;

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

	void PlayAudioClip(AudioClip clip) {
		audio.clip = clip;
		audio.Play ();
	}

	AudioClip SelectAudioClip(float resultCash, float startCash) {
		float percentage = resultCash / startCash;
		if (percentage >= 100.0f) {
			return audioClipResultPerfect;
		} else if (percentage >= 90.0f) {
			return audioClipResultGreat;
		} else if (percentage >= 80.0f) {
			return audioClipResultGood;
		} else if (percentage <= 0.0f) {
			return audioClipResultFail;
		} else {
			return audioClipResultOK;
		}
	}

	public void ShowResultLayer(float resultCash, float startCash) {
		this.gameObject.SetActive(true);
		SetText (resultCash);
		PlayAudioClip( SelectAudioClip (resultCash, startCash) );
	}

	public void HideResultLayer() {
		this.gameObject.SetActive(false);
	}

	public void OnResultButtonClicked() {
		Application.LoadLevel ("MainScene");
	}
}
