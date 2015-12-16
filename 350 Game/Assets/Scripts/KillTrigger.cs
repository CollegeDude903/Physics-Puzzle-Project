/// <summary>
/// Written by Jason Sullender
/// This class is written for the KillTrigger game object that is a box collider that is a trigger
/// </summary>

using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {
	public static bool pauseTimer;
	/// <summary>
	/// When the player enters the KillTrigger game object trigger destroy player then load level
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col)
	{

		
		if (col.tag == ("Player")) {
			Destroy (col.gameObject);	
			RestartLevel.Restart ();
		} else if (col.tag == ("Blocks")) {
			Destroy (col.gameObject);
		}
		if (col.name == ("Enemy")){
			if (LevelOn.levelOn == 1){
				LevelOn.levelOn = 2;
			} else if (LevelOn.levelOn == 2){
				LevelOn.levelOn = 3;
			} else if (LevelOn.levelOn == 3){
				LevelOn.levelOn = 4;
			}
			pauseTimer = true;
			RestartLevel.Restart();
		}
		
	}
}
