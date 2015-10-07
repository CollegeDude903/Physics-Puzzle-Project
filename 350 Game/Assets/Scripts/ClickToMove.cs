using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	
	public float moveSpeed = 13;
	public float turnSpeed = 200;
	public float coneRadius = 225;
	bool turning;
	int canMove;
	Vector3 newPos;
	Vector3 playerPos;
	Vector3 targetDir;
	Vector3 forward;

	void Start() {
		playerPos = transform.position;

	}

	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			canMove = 1;
			turning = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) newPos = hit.point;
		}
		playerPos.y = transform.position.y;
		newPos.y = playerPos.y;


		if (turning == true){
			targetDir = transform.position - newPos;
			forward = transform.forward;
			Rotate ();

			float angle = SignedAngleBetween(targetDir, playerPos, Vector3.up);
			float angle2 = Quaternion.LookRotation(forward).eulerAngles.y;
			angle2 -= 90;
			float facingAngle = KeepDegreesUnder180(angle2);
			float angleBetween = angle - facingAngle;
			float angleResult = Mathf.Abs(KeepDegreesUnder180(angleBetween));


			if (angleResult <= coneRadius/2){
				if (canMove == 1) canMove = 2;
				if (angleResult <= 1) turning = false;
			}

		}

		if (canMove == 2) {
			transform.position = Vector3.MoveTowards (transform.position, newPos, moveSpeed * Time.deltaTime);
			
			float distBetween = Vector3.Distance (transform.position, newPos);
			if (distBetween <= 1)canMove = 0;
		}
	}

	//Function for yielding positive and negative values for an angle between 2 objects. Replaces Vector3.Angle
	float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n){
		// code referenced from stackoverflow
		// angle in [0,180]
		float angle = Vector3.Angle(a,b);
		float sign = Mathf.Sign(Vector3.Dot(n,Vector3.Cross(b,a)));
		
		// angle in [-179,180]
		float signed_angle = angle * sign;
		
		// angle in [0,360] (not used but included here for completeness)
		//float angle360 =  (signed_angle + 180) % 360;
		return signed_angle;
	}

	float KeepDegreesUnder180(float x){
			if (x > 180)
				x -= 360;
			else if (x < -180)
				x += 360;
			return x;
	}

	void Rotate() {
		Vector3 lookDelta = (newPos - transform.position);
		Quaternion targetRot = Quaternion.LookRotation(lookDelta);
		float rotSpeed = turnSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed);
	}
}
