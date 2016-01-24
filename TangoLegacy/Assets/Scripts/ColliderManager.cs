using UnityEngine;

using System.Collections;


	public class ColliderManager : MonoBehaviour {

	//TODO i tiles non sono ancora funzionanti, bisogna linkarli agli oggetti dell editor per recuperarne la posizione dei vettori
		static int[,] grid = new int[3,3];
	//	GameObject[,] tiles;
		public GameObject[] places;

	void Start () {
		clearGrid ();
		//	recreateGrid (size);
		}


		/**
		 * Check if there is more than a character in a single ceil position 
		*/
		public static bool anyCollision(){
			for (int row=0; row<3; row++) {
				for (int col=0; col<3; col++) {
					
					if(grid[row,col]>1){
						return true;
					}
				}
			}
			return false;
		}

	
		public  static void clearGrid(){
			for (int row=0; row<3; row++) {
				for (int col=0; col<3; col++) {
					grid[row,col]=0;
				}
			}
		}
		 
	public static void addCharacterToPosition(int[]  coords){
			int row = coords [0];
			int column = coords [1];
			if (row < 3 &&   column < 3) {
				grid[row,column]+=1;	
			}
		}

/*		public void recreateGrid(int s){
			size = s;
			grid = new int[size, size];
			clearGrid ();

			tiles = new GameObject[size, size];
			for (int row=0; row<size; row++) {
				for (int col=0; col<size; col++) {

				//TODO per usare le tail è necessario aggiornare gli oggetti dell'editor
					tiles[row,col] = new GameObject();
					tiles [row, col] = GameObject.Instantiate(Resources.Load ("Tileset_2 meno saturo")) as GameObject;
					tiles[row,col].transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
					SpriteRenderer sr = tiles [row, col].GetComponent<SpriteRenderer> ();
					tiles[row,col].transform.position =
						new Vector3((col * sr.bounds.extents.x) + (row * sr.bounds.extents.x), (col * sr.bounds.extents.y) - (row * sr.bounds.extents.y) , 0);
	

				}
			}
		}


		public Vector2 getTileMiddle(int row, int column) {
			SpriteRenderer sr = tiles [row, column].GetComponent<SpriteRenderer> ();
			var vec = new Vector2 (sr.bounds.center.x, sr.bounds.center.y);
			return vec;
		}
*/

}