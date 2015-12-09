using UnityEngine;
using System.Collections;

public class PlayerAnimController : MonoBehaviour {

	public static Animator anim;
	public static bool isMoving;

	void Start () {
	
		anim = GetComponent<Animator>();

	}

	void Update () {
		print (FlyController.isFalling);
		if (FlyController.isFlying == false && FlyController.isFalling == false) {
			if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
				if (isMoving == false){
					anim.Play ("Run");
					isMoving = true;
				}
			} else isMoving = false;
			if (isMoving == false) anim.Play ("Stand");
		}
	}
}
