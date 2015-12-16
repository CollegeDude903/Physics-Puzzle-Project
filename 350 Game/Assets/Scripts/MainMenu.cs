// <summary>
// Written by Jason Sullender
// This Main Menu class represents the Main Menu scene where when the Play Game button is pressed
// the Scene4(GitHub) Scene is then started up. The Exit button will then quit the application
// </summary>

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// PlayGame() is set for the Play button on the Main Menu scene which loads the level called
	/// Scene4(GitHub)
	/// </summary>
	public void PlayGame()
	{
		Application.LoadLevel ("Level1");
	}
	/// <summary>
	/// ExitGame() is set for the Exit button on the Main Menu scene which quits the application
	/// </summary>
	public void ExitGame()
	{
		Application.Quit();
	}
}
