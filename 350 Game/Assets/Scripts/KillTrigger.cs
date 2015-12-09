/// <summary>
/// Written by Jason Sullender
/// This class is written for the KillTrigger game object that is a box collider that is a trigger
/// </summary>

using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {
	/// <summary>
	/// When the player enters the KillTrigger game object trigger destroy player then load level
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col)
	{

		
		if (col.tag == ("Player")) {
			Destroy (col.gameObject);	
			ReloadGame ();
		} else if (col.tag == ("Blocks")) {
			Destroy (col.gameObject);	
		}
		
	}
	
	public void ReloadGame()
	{			
	
		Application.LoadLevel ("Scene6");//loads scene

	}
}
