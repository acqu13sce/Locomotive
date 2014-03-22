using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainMovement : MonoBehaviour {
	public float defaultSpeed = 2.0f;
	public Vector2 nextPosition;
	public float toGo = 99999f;
	private bool moving = false;
	public Queue<Vector2> positions = new Queue<Vector2>();
	// Use this for initialization
	void Start () {
		LoadNextPosition ();
		moving = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving)
			return;

		var speed = defaultSpeed;
		if (Input.GetKey("space")) {
			speed = 5;
		}
		var trainPos = transform;
		var firstPointPos = nextPosition;

		var r = Mathf.Atan ((trainPos.position.x - firstPointPos.x) / (trainPos.position.y - firstPointPos.y)) * Mathf.Rad2Deg * -1;
		if (firstPointPos.y <= trainPos.position.y)
				r += 180f;
		transform.localEulerAngles = new Vector3 (0, 0, r);
		transform.position += transform.up * speed * Time.deltaTime;


		var newDistance = Vector2.Distance (
			new Vector2 (transform.position.x, transform.position.y), 
			nextPosition);

		if (newDistance > toGo) {
			//destination reached
			LoadNextPosition();
			toGo = Vector2.Distance (
				new Vector2 (transform.position.x, transform.position.y), 
				nextPosition);
		} else {
			toGo = newDistance;
		}
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Finish") {
			moving = false;
			collision.GetComponent<LevelComplete> ().Win ();
		} 
		else if (collision.gameObject.tag == "GameOver") {
			moving = false;
			Camera.main.GetComponent<LevelStart>().Lose();
		}
	}

	private void LoadNextPosition(){
		if (positions.Count == 0) {
			moving = false;
			return;
		}
		nextPosition = positions.Dequeue ();
	}
}
