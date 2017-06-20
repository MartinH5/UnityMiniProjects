using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {


	//Grid consist of a board of 5xs and 6ys
	GameObject[,] grid = new GameObject[6,5];

	private Vector3 spawnPos = new Vector3(0,0,0);
	private Vector3 addingToX = new Vector3(1,0,0);
	private Vector3 addingToZ = new Vector3(-5f,0,1);
	private int roundCount;
	public GameObject usingPiece;
	private GameObject tempGameObject;
	private Vector2 tempCoordinate;

	private int player1Count;
	private int player2Count;

	public GameObject p1;
	public GameObject p2;

	// Use this for initialization
	void Start () {
		SetupGame (p1,p2);
		roundCount = 1;
		player1Count = 0;
		player2Count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)){
			usingPiece = GetPiece (tempGameObject);
			Debug.Log ("The Piece has: " + usingPiece.tag + " tag." + "And the roundCount is: " + roundCount);
		}
	}

	void ResetSpawnPos (){
		spawnPos = new Vector3 (0, 0, 0);
	}


	GameObject GetPiece(GameObject temp){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 100.0f)){
			temp = hit.transform.gameObject;
		}

		if (temp.tag == "player1" && roundCount % 2 == 1) {
		//	tempCoordinate = temp.transform.position;
			return temp;

		}

		if (temp.tag == "player2" && roundCount % 2 == 0) {
		//	tempCoordinate = temp.transform.position;
			return temp;
		} 
		return temp;
	}

	public void MoveLeft(){
		if (roundCount % 2 == 1 && usingPiece.tag == "player1") {
			if (grid [(int)(usingPiece.transform.position.x - 1), (int)(usingPiece.transform.position.z + 1)] == null) {
				tempCoordinate = new Vector2 (usingPiece.transform.position.x, usingPiece.transform.position.z);
				usingPiece.transform.position = usingPiece.transform.position + new Vector3 (-1, 0, 1f);
				grid [((int)usingPiece.transform.position.x), (int)(usingPiece.transform.position.z)] = usingPiece;
				grid [(int)tempCoordinate.x, (int)tempCoordinate.y] = null;
				roundCount++;
			}
		
			else if (grid[(int)(usingPiece.transform.position.x - 2), (int)(usingPiece.transform.position.z + 2)] == null) {
				tempCoordinate = new Vector2 (usingPiece.transform.position.x, usingPiece.transform.position.z);
				thisRaycast (new Vector3 (usingPiece.transform.position.x - 1, 1 ,usingPiece.transform.position.z + 1));
				usingPiece.transform.position = usingPiece.transform.position + new Vector3 (-2, 0, 2f);
				grid [((int)usingPiece.transform.position.x), (int)(usingPiece.transform.position.z)] = usingPiece;
				grid [(int)tempCoordinate.x, (int)tempCoordinate.y] = null;
				Destroy (grid[(int)(usingPiece.transform.position.x - 1), (int)(usingPiece.transform.position.z + 1)]);
				player2Count--;
				roundCount++;
			}
		}
		if (roundCount % 2 == 0 && usingPiece.tag == "player2"){
			if (grid [(int)(usingPiece.transform.position.x - 1), (int)(usingPiece.transform.position.z - 1)] == null) {
			tempCoordinate = new Vector2(usingPiece.transform.position.x, usingPiece.transform.position.z);
			usingPiece.transform.position = usingPiece.transform.position + new Vector3(-1,0,-1f);
			grid[((int)usingPiece.transform.position.x ), (int)(usingPiece.transform.position.z)] = usingPiece;
			grid[(int)tempCoordinate.x,(int)tempCoordinate.y] = null;
			roundCount++;
		}
			else if (grid[(int)(usingPiece.transform.position.x - 2), (int)(usingPiece.transform.position.z - 2)] == null) {
				tempCoordinate = new Vector2 (usingPiece.transform.position.x, usingPiece.transform.position.z);
				thisRaycast (new Vector3 (usingPiece.transform.position.x - 1, 1 ,usingPiece.transform.position.z - 1));
				usingPiece.transform.position = usingPiece.transform.position + new Vector3 (-2, 0, -2f);
				grid [((int)usingPiece.transform.position.x), (int)(usingPiece.transform.position.z)] = usingPiece;
				grid [(int)tempCoordinate.x, (int)tempCoordinate.y] = null;
				Destroy (grid[(int)(usingPiece.transform.position.x - 2), (int)(usingPiece.transform.position.z - 2)]);
				player1Count--;
				roundCount++;
			}
		}
	}

	public void MoveRight(){
		if (roundCount % 2 == 1 && usingPiece.tag == "player1"){
			if (grid[(int)(usingPiece.transform.position.x + 1), (int)(usingPiece.transform.position.z + 1)] == null) {
				tempCoordinate = new Vector2 (usingPiece.transform.position.x, usingPiece.transform.position.z);
				usingPiece.transform.position = usingPiece.transform.position + new Vector3 (1, 0, 1f);
				grid [((int)usingPiece.transform.position.x), (int)(usingPiece.transform.position.z)] = usingPiece;
				grid [(int)tempCoordinate.x, (int)tempCoordinate.y] = null;
				roundCount++;
			}
			else if (grid[(int)(usingPiece.transform.position.x + 2), (int)(usingPiece.transform.position.z + 2)] == null) {
				tempCoordinate = new Vector2 (usingPiece.transform.position.x, usingPiece.transform.position.z);
				thisRaycast (new Vector3 (usingPiece.transform.position.x + 1, 1 ,usingPiece.transform.position.z + 1));
				usingPiece.transform.position = usingPiece.transform.position + new Vector3 (2, 0, 2f);
				grid [((int)usingPiece.transform.position.x), (int)(usingPiece.transform.position.z)] = usingPiece;
				grid [(int)tempCoordinate.x, (int)tempCoordinate.y] = null;
				Destroy (grid[(int)(usingPiece.transform.position.x + 2), (int)(usingPiece.transform.position.z + 2)]);
				player2Count--;
				roundCount++;
			}
	}
		if (roundCount % 2 == 0 && usingPiece.tag == "player2"){
			if (grid[(int)(usingPiece.transform.position.x + 1), (int)(usingPiece.transform.position.z - 1)] == null) {
				tempCoordinate = new Vector2 (usingPiece.transform.position.x, usingPiece.transform.position.z);
				usingPiece.transform.position = usingPiece.transform.position + new Vector3 (1, 0, -1f);
				grid [((int)usingPiece.transform.position.x), (int)(usingPiece.transform.position.z)] = usingPiece;
				grid [(int)tempCoordinate.x, (int)tempCoordinate.y] = null;
				roundCount++;
			}
			else if (grid[(int)(usingPiece.transform.position.x + 2), (int)(usingPiece.transform.position.z - 2)] == null){
				tempCoordinate = new Vector2 (usingPiece.transform.position.x, usingPiece.transform.position.z);
				thisRaycast (new Vector3 (usingPiece.transform.position.x + 1, 1 ,usingPiece.transform.position.z - 1));
				usingPiece.transform.position = usingPiece.transform.position + new Vector3 (2, 0, -2f);
				grid [((int)usingPiece.transform.position.x), (int)(usingPiece.transform.position.z)] = usingPiece;
				grid [(int)tempCoordinate.x, (int)tempCoordinate.y] = null;
				Destroy (grid[(int)(usingPiece.transform.position.x + 1), (int)(usingPiece.transform.position.z - 1)]);	
				player2Count--;
				roundCount++;
			}
		}
	}

	public void SetupGame(GameObject p1, GameObject p2){

		ResetSpawnPos ();
		int k = 0;
		for (int z = 0; z < 2; z++){
			for (int x = 0; x < grid.GetLength(0); x++){
				if (x < 6 && (x+1) % 2 == 1){
					GameObject p = (GameObject)Instantiate(p1, spawnPos,Quaternion.identity);
					player1Count++;
					if (k < 1) {
						grid [x, z] = p;
					} else {
						grid [(x+1), z] = p;
						Debug.Log (grid[(x+1),z]);
					}
				}
				spawnPos += addingToX;
				k++;
			}
			spawnPos += addingToZ;
		}
		spawnPos = new Vector3 (1f,0.5f,3f);
		int e = 0;
		for (int z = 3; z < 5; z++){
			for (int x = 1; x < grid.GetLength(0); x++){
				if (x < 6 && x % 2 == 1){
					GameObject p = (GameObject)Instantiate(p2, spawnPos,Quaternion.identity);
					player2Count++;
					if (e < 1) {
						grid [x, z] = p;
					} else {
						grid[x, z] = p;
					}
				}
				spawnPos += addingToX;
				e++;
			}
			spawnPos += addingToZ + new Vector3(-1, 0, 0);
		}
	}

	void thisRaycast(Vector3 start){
		RaycastHit hit;
		Ray ray = new Ray (start + new Vector3(0,3,0),new Vector3(0,-1,0));

		if (Physics.Raycast(ray,out hit, 100)){
			if (hit.transform.gameObject.tag == "player1" || hit.transform.gameObject.tag == "player2"){
				Destroy(hit.transform.gameObject);
			}
		}
	}
}
