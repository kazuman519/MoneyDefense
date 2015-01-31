using UnityEngine;
using System.Collections;

public class MoneyController : MonoBehaviour {
	
	public float destroyTime = 1.0f;
	private float previousTime;

	// Use this for initialization
	void Start () {
		previousTime = Time.renderedFrameCount;
		Object.Destroy(this.gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.rigidbody2D.velocity = new Vector2(0, this.gameObject.rigidbody2D.velocity.y);
	}
}
