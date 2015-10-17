using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour {

	public Rigidbody rb;
	public float thrust = 300;
	public float maxVelocity = 250;
	public float explosionForce = 40;
	public float explosionRadius = 20;
	public float fuelTimer;
	public float maxFuel = 10f;
	float stopSpeed;
	bool isGrounded = true;
	bool needToRefuel = false;

	void Start(){
		rb = GetComponent<Rigidbody>();
		fuelTimer = maxFuel;
	}

	void FixedUpdate () {

		float moveVertical = Input.GetAxis ("Fly");
		Vector3 movement = new Vector3 (0, moveVertical, 0);

		//Add a little "Umph" to every first take-off
		if (Input.GetAxis ("Fly") > 0 && isGrounded == true) {
			rb.AddExplosionForce (explosionForce, transform.position, explosionRadius);
		}


		if (isGrounded == true) {
			fuelTimer += Time.fixedDeltaTime;
			if (fuelTimer >= maxFuel) fuelTimer = maxFuel;
			needToRefuel = false;

		} else {
			fuelTimer -= Time.fixedDeltaTime;
			if (fuelTimer <= 0) {
				fuelTimer = 0;
				needToRefuel = true;
				rb.WakeUp ();
			}
			if (needToRefuel == false) {
				
				//Hover in mid-air when not flying up or down
				if (Input.GetButtonUp ("Fly")) {
					stopSpeed = 1;
				}
				//Move up or down when holding down "Q" or "E"
				if (Input.GetButton ("Fly")) {
					rb.velocity = movement * thrust * Time.fixedDeltaTime;
				} else if (isGrounded == false) {
					
					stopSpeed *= .99f;
					if (rb.velocity.y * movement.y > 0) {
						rb.velocity = movement * stopSpeed;
					} else {
						rb.velocity = Vector3.zero;
						rb.angularVelocity = Vector3.zero;
						rb.Sleep ();
					}
				}
			} 
		}
		//print (transform.position.y);
		//////////////////////////////////////////

		//Clamps the velocity so you don't go flying off the screen
		if (Mathf.Abs(rb.velocity.y) > maxVelocity) {;
			rb.velocity = movement * maxVelocity * Time.fixedDeltaTime;
		}
		print (fuelTimer);
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
