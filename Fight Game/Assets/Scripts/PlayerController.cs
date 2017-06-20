using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int playerNumber; 
	private Rigidbody rb;
	public int moveSpeed;
	private Vector3 direction;
	private Transform enemyTarget;
	public ArmController left;
	public ArmController right;
	float attackCDLeft;
	float attackCDRight;


	//private float attackCD;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		attackCDLeft = Time.time;
		attackCDRight = Time.time;

		if(playerNumber == 1){
			GameObject enemy = GameObject.FindGameObjectWithTag ("player2");
			enemyTarget = enemy.transform;
		}
		if(playerNumber == 2){
			GameObject enemy = GameObject.FindGameObjectWithTag ("player1");
			enemyTarget = enemy.transform;
		}
	}
	// Update is called once per frame
	void Update () {

		if (playerNumber == 1){
			
			float vertical = Input.GetAxis ("P1_Vertical");
			float horizontal = Input.GetAxis ("P1_Horizontal");
			direction = new Vector3 (horizontal,0f,vertical);
			rb.transform.LookAt(enemyTarget);
			rb.velocity = direction * moveSpeed * Time.deltaTime;	

			if(Input.GetButtonDown ("P1_AttackLeft") & Time.time > attackCDLeft) {
				left.Attack ();
				float attackCDLeft = Time.time + 1f; 
			}
			if(Input.GetButtonDown ("P1_AttackRight") & Time.time > attackCDLeft) {
				left.Attack ();
				float attackCDLeft = Time.time + 1f; 
			}
		}

		if (playerNumber == 2){
			float vertical = Input.GetAxis ("P2_Vertical");
			float horizontal = Input.GetAxis ("P2_Horizontal");
			direction = new Vector3 (horizontal,0f,vertical);
			rb.transform.LookAt(enemyTarget);
			rb.velocity = direction * moveSpeed * Time.deltaTime;	
	}
}
}
