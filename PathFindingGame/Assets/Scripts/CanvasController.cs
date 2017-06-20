using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasController : MonoBehaviour {
	GameObject round;
	Text roundText;
	int counter;
	IEnumerator coroutine;
	string currentRound;

	// Use this for initialization
	void Start () {
		round = GameObject.FindGameObjectWithTag("roundtext");
		roundText = round.GetComponent<Text> ();
		counter = 1;

		coroutine = SetRound1Active();
		StartCoroutine (coroutine);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SetRound1Active (){
	    
		roundText.text = roundText.text + counter;
		yield return new WaitForSeconds (2);
		round.SetActive (false);
	}

	public void NextRound(){
		counter++;
		roundText.text = "Round " + counter;
		round.SetActive (true);

	}

}
