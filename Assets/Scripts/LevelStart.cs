using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour {
	public GameObject[] availableTiles;
	public GameObject player;
	public GameObject blankTile;
	// Use this for initialization
	private TrainMovement train;
	public GameObject losingWindow;

	public void Lose(){
		var lose = Instantiate (losingWindow) as GameObject;
		lose.transform.position = Vector3.zero;
	}

	public GameObject[,] tiles = new GameObject[Constants.horizontalTiles,Constants.verticalTiles];
	void Awake(){
		var firstPoint = GameObject.Find ("firstPoint");
		var secondPoint = GameObject.Find ("secondPoint");
		
		train = player.GetComponent<TrainMovement> ();
		train.positions = new System.Collections.Generic.Queue<Vector2> ();

		train.positions.Enqueue (firstPoint.transform.position.toVector2 ());
		train.positions.Enqueue (secondPoint.transform.position.toVector2 ());
	}

	void Start () {
		var randx = Random.Range (0, Constants.horizontalTiles - 1);
		var randy = Random.Range (0, Constants.verticalTiles - 1);
		for (int i = 0; i < Constants.horizontalTiles; i++) {
			for (int j = 0; j < Constants.verticalTiles; j++) {
				GameObject block;

				if(i == randx && j == randy){
					block = Instantiate(blankTile) as GameObject;	
				}
				else{
					block = Instantiate(availableTiles[Random.Range(0,availableTiles.Length)]) as GameObject;	
				}
				block.transform.localScale = new Vector3(Constants.tileScale, Constants.tileScale);
				block.transform.position = new Vector3 (i * Constants.tileSeparator -5.5f, j * - Constants.tileSeparator + 4 , 0);	
				var tileScript = block.GetComponent<Tile>();
				tileScript.x = i;
				tileScript.y = j;
				tiles[i,j] = block;
			}
		}
		train.transform.localScale = new Vector3 (Constants.trainScale, Constants.trainScale);
		train.positions.Enqueue (tiles [0, 0].transform.position.toVector2 ());


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
