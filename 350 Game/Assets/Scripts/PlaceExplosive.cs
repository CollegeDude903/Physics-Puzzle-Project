using UnityEngine;
using System.Collections;

public class PlaceExplosive : MonoBehaviour {

	public Rigidbody explosive;
	public float shootPower = 10;
	public int bombCount = 3;


	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("PlaceBomb") & bombCount > 0){
			bombCount --;
			Rigidbody clone;
			clone = Instantiate(explosive, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * shootPower);
		}
	}
}
