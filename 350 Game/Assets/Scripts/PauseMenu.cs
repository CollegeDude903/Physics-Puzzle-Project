/// <summary>
///Written by Jason Sullender
///This PauseMenu class is written to be able to pause and reset the game right now it is setup
 ///in the Scene4(GitHub) scene which currently has two buttons the Pause button and the Reset
/// button. 
/// </summary>

using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	bool paused =false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/// <summary>
	///Every update check while the Scene4(GitHub) scene is running will check if the P button is
 /// the code will go to the Pause() function whereas if the F1 key is pressed the code will go
	/// to the Reset() function
	/// </summary>
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) { 
			Pause ();
		}
		if(Input.GetKeyDown (KeyCode.R))
		   {
			Reset ();

		}
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit();
			
		}
	
	}
	/// <summary>
	///The Pause() function will check if the paused variable is not true
 /// This function will do operations depending on the paused variable state
	/// </summary>
	public void Pause()
	{
		//Check state of paused
			paused=!paused;
		//paused is true set the timescale of the scene to zero
		if (paused) {
			Time.timeScale=0;//When the timescale is zero the scene state is stopped and stored
		}
		//Operation for when the paused variable is false
		if (!paused) {
			Time.timeScale=1;//Timescale equal to 1 so that the scene state can go back to running before set to 0
		}

	}
	/// <summary>
	/// The Reset() function is used to reload the Scene4(GitHub) scene from its start state
	/// </summary>
	public void Reset()
	{
		RestartLevel.Restart ();
	}
}
