using UnityEngine;
using System.Collections;

public class TrainPositionQueuer : MonoBehaviour {
	public Vector2 fromLeft;
	public Vector2 fromRight;
	public Vector2 fromTop;
	public Vector2 fromBottom;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		var train = Camera.main.GetComponent<LevelStart> ().player;

		Vector2 change = Vector2.zero;

		if ((train.transform.position.x - transform.position.x) < -0.3f) {
			//from left
			change = fromLeft;
		} else if ((train.transform.position.x - transform.position.x) > 0.3f) {
			//from right
			change = fromRight;
		}else if ((train.transform.position.y - transform.position.y) > 0.3f) {
			//from top
			change = fromTop;
		} else if ((train.transform.position.y - transform.position.y) < -0.3f) {
			//from bottom
			change = fromBottom;
		}

		var newX = (change.x * 2f) + transform.parent.transform.position.x;
		var newY = (change.y * 2f) + transform.parent.transform.position.y;

		train.GetComponent<TrainMovement> ().positions.Enqueue (new Vector2(newX, newY));
	}
}
