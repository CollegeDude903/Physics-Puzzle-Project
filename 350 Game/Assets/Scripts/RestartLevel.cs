using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	string levelText;

	public static void Restart() {	
		if (LevelOn.levelOn == 1) {
			Application.LoadLevel ("Level1");//loads scene
		} else if (LevelOn.levelOn == 2) {
			Application.LoadLevel ("Level2");
		} else if (LevelOn.levelOn == 3) {
			Application.LoadLevel ("Level3");
		} else if (LevelOn.levelOn == 4) {
			Application.LoadLevel ("MainMenu");
		}
	}
}
