using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public int x = 0;
	public int y = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		var tiles = Camera.main.GetComponent<LevelStart> ().tiles;
		foreach (var item in tiles) {
			if(item.tag == "BlankTile" ){
				var tempX = x;
				var tempY = y;
				var blankTile = item.GetComponent<Tile>();

				if((x + 1 == blankTile.x && y == blankTile.y) ||
				   (x - 1 == blankTile.x && y == blankTile.y) ||
				   (y + 1 == blankTile.y && x == blankTile.x) ||
				   (y - 1 == blankTile.y && x == blankTile.x)){
						x = blankTile.x;
						y = blankTile.y;
						
						
						blankTile.x = tempX;
						blankTile.y = tempY;
						
						item.transform.position = new Vector3 (blankTile.x * Constants.tileSeparator -5.5f, blankTile.y * -Constants.tileSeparator + 4 , 0);
						transform.position = new Vector3 (x * Constants.tileSeparator -5.5f, y * -Constants.tileSeparator + 4 , 0);
				}
			}
		}
	}
}
