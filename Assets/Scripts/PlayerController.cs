using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//const float jumpHeightMax
	public float speed;
	public float jumpHeight = 5;
	Rigidbody2D rigidBody;
	bool grounded = true;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		Move ();

		if (grounded == true) {
			Jump ();
		}
	}

	void Move() {
		if(Input.GetKey(KeyCode.D)) {
			rigidBody.AddForce(transform.right * speed);
		}

		if(Input.GetKey(KeyCode.A)) {
			rigidBody.AddForce(transform.right * -speed);
		}
	}


	void Jump(){
		if (Input.GetButtonDown ("Jump")) {
			rigidBody.AddForce (transform.up * jumpHeight);
			grounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		}
	}



}
