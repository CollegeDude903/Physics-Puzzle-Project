using UnityEngine;
using System.Collections;

public class TwinStickController : MonoBehaviour {
	
	public Transform player;
	public float moveSpeed = 6;
	public float turnSpeed = 500;
	public float coneRadius = 225;
	Vector3 newPos;
	Vector3 playerPos;
	Vector3 targetDir;
	Vector3 forward;



	void Update () {
		Raycast ();
		Rotate ();
		Movement ();
	}
	//Using a plane I instantiated earlier I don't have to worry about raycasts not hitting empty space.
	void Raycast(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			newPos = hit.point;
		}
		playerPos.y = transform.position.y;
		newPos.y = playerPos.y;
	}

	//Rotates the player using the "RotateTowards" function in the Quaternion class.
	void Rotate() {
		Vector3 lookDelta = (newPos - player.position);
		Quaternion targetRot = Quaternion.LookRotation(lookDelta);
		float rotSpeed = turnSpeed * Time.deltaTime;
		player.rotation = Quaternion.RotateTowards(player.rotation, targetRot, rotSpeed);
	}
	//Moves the player with W,A,S,D or arrow keys. Note to self - GetAxis smooths the translation while
	//GetAxisRaw makes it instant due to non-interpolation.
	void Movement(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		player.Translate (movement * moveSpeed * Time.deltaTime, Space.World);
	}
}