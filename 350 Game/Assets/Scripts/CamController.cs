using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {

	public int edgeBoundary = 20;

	public Transform player;
	public float horizontalSpeed = 25;
	public float verticalSpeed = 18;
	public float cameraRotateSpeed = 80;
	public float cameraDistance = 20;
	Vector3 camPos;
	
	float curDistance;


	void Update () {

		CamPosition ();

		/*
		if (Input.mousePosition.y < Screen.height / edgeBoundary) {
			transform.position += Vector3.back * Time.deltaTime * verticalSpeed;
		}
		if (Input.mousePosition.y > Screen.height - Screen.height / edgeBoundary) {
			transform.position += Vector3.forward * Time.deltaTime * verticalSpeed;
		}
		if (Input.mousePosition.x < Screen.width / edgeBoundary) {
			transform.position += Vector3.left * Time.deltaTime * horizontalSpeed;
		}
		if (Input.mousePosition.x > Screen.width - Screen.width / edgeBoundary) {
			transform.position += Vector3.right * Time.deltaTime * horizontalSpeed;
		}
		*/


		RaycastHit hit;
		if (Physics.Raycast (transform.position, -transform.up, out hit, 100)) {
			curDistance = Vector3.Distance(transform.position, hit.point);
		}
		if(curDistance != cameraDistance) {
			float difference = cameraDistance - curDistance;
			transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0,difference,0),Time.deltaTime);
		}
	}
	void CamPosition(){
		camPos = transform.position;
		camPos.x = player.position.x;
		camPos.z = player.position.z - 10;
		camPos.y = transform.position.y;
		transform.position = camPos;
	}
}
