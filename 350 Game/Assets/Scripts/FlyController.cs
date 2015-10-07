using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour {

	public Rigidbody rb;
	public float thrust;
	public float maxVelocity;
	public float explosionForce;
	public float explosionRadius;
	float stopSpeed;
	bool isGrounded = true;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {

		float moveVertical = Input.GetAxis ("Fly");
		Vector3 movement = new Vector3 (0, moveVertical, 0);

		if (Input.GetAxis ("Fly") > 0 && isGrounded == true) {
			rb.AddExplosionForce (explosionForce, transform.position, explosionRadius);
		}
		//Hover in mid-air when not flying up or down
		if (Input.GetButtonUp ("Fly")){
			stopSpeed = 1;
		}
		if (Input.GetButton ("Fly")) {
			rb.velocity =  movement * thrust * Time.fixedDeltaTime;
		} 
		else if (isGrounded == false) {
			stopSpeed *= .99f;
			if (rb.velocity.y * movement.y > 0){
				rb.velocity = movement * stopSpeed;
			}
			else {
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
				rb.Sleep();
			}
		}
		//print (transform.position.y);
		//////////////////////////////////////////

		//Clamps the velocity so you don't go flying off the screen
		if (Mathf.Abs(rb.velocity.y) > maxVelocity) {;
			rb.velocity = movement * maxVelocity * Time.fixedDeltaTime;
		}
		//print (movement * -thrust);
		///////////////////////////////////////////////////////////
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Floor") {
			isGrounded = true;
		}
	}
	void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "Floor") {
			isGrounded = false;
		}
	}
}
