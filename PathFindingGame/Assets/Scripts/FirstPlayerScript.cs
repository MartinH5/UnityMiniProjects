using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FirstPlayerScript : MonoBehaviour {

	public GameObject canvasMaster;
	Vector3 target;
	NavMeshAgent agent;
	public GameObject particle;
	public GameObject player;
	public GameObject tempTarget;
	public GameObject goHere;
	Rigidbody rb; 
	CanvasController cc;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		rb = GetComponent<Rigidbody> ();
		cc = canvasMaster.GetComponent<CanvasController> ();
	}
	
	// Update is called once per frame
	void Update (){		
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)){
				agent.destination = hit.point;
		}
	}

}
	IEnumerator OnTriggerEnter(Collider other){
		if (other.tag == "Tele") {
			cc.NextRound();
			Camera.main.transform.position = new Vector3(0,15,35);

			gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			Vector3 moreZ = new Vector3 (0, 0, 13);
			yield return new WaitForSeconds (2);
			rb.transform.position = moreZ;
			gameObject.GetComponent<NavMeshAgent> ().enabled = true;

		/*	gameObject.GetComponent<NavMeshAgent> ().enabled = false;
			player.SetActive (false);
			goHere = GameObject.FindGameObjectWithTag ("Finish");
			Vector3 moreY = new Vector3 (0,10,0);
			rb.position = goHere.transform.position + moreY;
			gameObject.GetComponent<NavMeshAgent> ().enabled = true;
			player.SetActive (true);
			Debug.Log (rb.position);
			Debug.Log (goHere.transform.position);*/
		}
	}

}
