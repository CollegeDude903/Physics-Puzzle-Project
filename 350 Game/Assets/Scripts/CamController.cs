using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {

	public int edgeBoundary = 20;

	public float horizontalSpeed = 25;
	public float verticalSpeed = 18;
	public float cameraRotateSpeed = 80;
	public float cameraDistance = 30;
	
	float curDistance;


	void Update () {

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


		float Rotation = Input.GetAxis ("Rotation");
		if (Rotation != 0) {
			transform.Rotate (Vector3.up,Rotation*cameraRotateSpeed*Time.deltaTime, Space.World);
		}


		RaycastHit hit;
		if (Physics.Raycast (transform.position, -transform.up, out hit, 100)) {
			curDistance = Vector3.Distance(transform.position, hit.point);
		}
		if(curDistance != cameraDistance) {
			float difference = cameraDistance - curDistance;
			transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0,difference,0),Time.deltaTime);
		}

	}
}
