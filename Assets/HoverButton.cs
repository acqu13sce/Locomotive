using UnityEngine;
using System.Collections;

public class HoverButton : MonoBehaviour {
	public Sprite hoverSprite;
	private Sprite originalSprite;
	public string action = "start";
	// Use this for initialization
	void Start () {
		var spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		originalSprite = spriteRenderer.sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		var spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = hoverSprite;
	}

	void OnMouseExit(){
		var spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = originalSprite;
	}

	void OnMouseUp(){
		if (action == "start") {
			Application.LoadLevel("game-level");
		}
	}
}
