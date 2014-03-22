using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseEnter(){
		this.gameObject.renderer.material.color = Color.green;
	}

	void OnMouseExit(){
		this.gameObject.renderer.material.color = Color.black;
	}

	void OnMouseUp(){
		Application.LoadLevel ("game-level");
	}
}
