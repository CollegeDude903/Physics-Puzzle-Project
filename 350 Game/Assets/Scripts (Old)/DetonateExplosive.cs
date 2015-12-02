using UnityEngine;
using System.Collections;

public class DetonateExplosive : MonoBehaviour {

	public float radius = 5;
	public float power = 400;
	public float explosiveLift = 10;


	void Update () {
		if (Input.GetButtonDown ("Detonate")) {
			Detonate();
		}
	}
	void Detonate(){
		Vector3 explosivePos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosivePos, radius);
		
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null && hit.tag == ("Blocks")) {
				rb.isKinematic = false;
				rb.AddExplosionForce(power, explosivePos, radius, explosiveLift);
			}
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Blocks") {
			Rigidbody explosiveRb = this.GetComponent<Rigidbody> ();
			explosiveRb.velocity = Vector3.zero;
		}
	}
	

}