using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {

	public int playerNumber;
	private float attackCD;
	private Vector3 originalPos;
	private Rigidbody rb;
	private Vector3 attackForce = new Vector3 (0,0,-1);
	private Rigidbody otherRB;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		originalPos = rb.transform.position;
	}
	
	// Update is called once per frame
	void Update () {



	}

	void OnTriggerEnter(Collider other){
		//On Negative force to enemy's Parent Object.
		otherRB = other.GetComponent<Rigidbody>();
		otherRB.AddForce (rb.GetRelativePointVelocity(rb.transform.position));

	}

	public void Attack(){
		rb.transform.position = originalPos + attackForce;
	}





}
