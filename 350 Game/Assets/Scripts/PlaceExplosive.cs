using UnityEngine;
using System.Collections;

public class PlaceExplosive : MonoBehaviour {

	public Rigidbody explosive;
	public float shootPower = 10;


	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("PlaceBomb")){
			Rigidbody clone;
			clone = Instantiate(explosive, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * shootPower);
		}
	}
}
