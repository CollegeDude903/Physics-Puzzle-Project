﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceExplosive : MonoBehaviour {
	
	public GameObject bombPrefab;
	public GameObject[] castlePrefabs;
	public int bombsStartWith = 3;
	public int bombsMaxCarry = 20;
	public float shootPower = 10;
	public float radius = 5;
	public float power = 400;
	public float explosiveLift = 10;
	public float bombOffset = 2;
	int bombsPlanted;
	int bombsCarrying;
	int castlePart;
	GameObject[] bombs;
	
	void Start(){
		bombsCarrying = bombsStartWith;
		bombs = new GameObject[bombsMaxCarry];
	}
	
	void Update () {
		if (Input.GetButtonDown("PlaceBomb") && bombsCarrying > 0 && bombsPlanted < bombsMaxCarry - 1){
			bombsPlanted++;
			//bombsMax --;
			bombs[bombsPlanted] = Instantiate(bombPrefab, transform.position + transform.forward*bombOffset, transform.rotation) as GameObject;

			/*bombRB[bombCount] = bomb2[bombCount].GetComponent<Rigidbody>();
			bombRB[bombCount].velocity = transform.TransformDirection(Vector3.forward * shootPower);
			*/
		}
		if (Input.GetButtonDown ("Detonate") && bombsPlanted > 0) {
			Detonate();
		}
	}
	void Detonate(){
		Vector3 explosivePos = bombs[1].transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosivePos, radius);
		
		foreach (Collider hit in colliders) {

			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null && hit.tag == ("Blocks")) {
				Vector3 hitPos = hit.transform.position;
				if (hit.name == ("HumanDrawBridge_00")){
					castlePart = 0;
				} else if(hit.name == ("HumanGate_00")){
					castlePart = 1;
				} else if(hit.name == ("HumanTower_00")){
					castlePart = 2;
				}else if(hit.name == ("HumanWall_00")){
					castlePart = 3;
				} else if(hit.name == ("HumanWood_00")){
					castlePart = 4;
				}
				else castlePart = 5;
				if (castlePart != 5){
					Instantiate(castlePrefabs[castlePart], hitPos, hit.transform.rotation);
					Destroy(hit.gameObject);
				}
			}
		}
		colliders = Physics.OverlapSphere (explosivePos, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null && hit.tag == ("Blocks")) {
				rb.isKinematic = false;
				if (hit.name == ("Enemy")) rb.AddExplosionForce(power * 1.5f, explosivePos, radius, explosiveLift);
				else rb.AddExplosionForce(power, explosivePos, radius, explosiveLift);
			}
		}
		for (int i = 1; i <= bombsPlanted; i++) {
			bombs[i - 1] = bombs[i];
		}
		Destroy(bombs[0]);
		bombsPlanted--;
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Blocks") {
			Rigidbody explosiveRb = this.GetComponent<Rigidbody> ();
			explosiveRb.velocity = Vector3.zero;
		}
	}
}
