using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {
	public GameObject winningWindow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Win(){
		var win = Instantiate (winningWindow) as GameObject;
		win.transform.position = Vector3.zero;
	}


}
