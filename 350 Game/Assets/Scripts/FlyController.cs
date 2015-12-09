using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour {
	
	public Rigidbody rb;
	public float thrust = 300;
	public float maxVelocity = 250;
	public float explosionForce = 40;
	public float explosionRadius = 20;
	public float fuelTimer;
	public float maxFuel = 2.5f;
	bool isGrounded = true;
	public static bool isFlying;
	public static bool isFalling;
	bool canFall;

	void Start(){
		rb = GetComponent<Rigidbody>();
		fuelTimer = maxFuel;
	}

	void FixedUpdate () {

		float moveVertical = Input.GetAxis ("Fly");
		Vector3 movement = new Vector3 (0, moveVertical, 0);

		if (Input.GetAxis ("Fly") > 0 && isGrounded == true) {
			rb.AddExplosionForce (explosionForce, transform.position, explosionRadius);
		}

		if (isGrounded == true) {
			isFalling = false;
			isFlying = false;
			canFall = false;
			if (PlayerAnimController.isMoving == true) PlayerAnimController.isMoving = false;
			fuelTimer += Time.fixedDeltaTime;
			if (fuelTimer >= maxFuel) fuelTimer = maxFuel;

		} else {
			//Move up when holding down space bar.
			if (Input.GetButton ("Fly")) {
				if (fuelTimer > 0){
					if (isFlying == false){
						PlayerAnimController.anim.Play ("Fly");
						isFlying = true;
						isFalling = false;
						canFall = true;
					}
					rb.velocity = movement * thrust * Time.fixedDeltaTime;
					fuelTimer -= Time.fixedDeltaTime;
					if (fuelTimer <= 0) {
						fuelTimer = 0;
					}
				}
			} else if (isGrounded == false && canFall == true) {
				isFlying = false;
				if (isFalling == false){
					isFalling = true;
					PlayerAnimController.anim.Play ("Fall");
				}
				if (rb.velocity.y * movement.y > 0) {
					rb.velocity = movement;
				}
			}
		}
		//print (transform.position.y);
		//////////////////////////////////////////

		//Clamps the velocity so you don't go flying off the screen
		if (Mathf.Abs(rb.velocity.y) > maxVelocity) {
			rb.velocity = movement * maxVelocity * Time.fixedDeltaTime;
		}
		//print (fuelTimer);
		///////////////////////////////////////////////////////////
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Blocks") {
			isGrounded = true;
		}
	}
	void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Blocks") {
			isGrounded = false;
		}
	}
}
