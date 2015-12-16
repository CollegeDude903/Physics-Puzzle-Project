using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float countdownTimer = 1f;
	public float secondsTillDefeat = 5f;
	public float timeTillRestart = 2f;
	public float levelTextFade = 3f;
	bool stopPlaying;
	public Image countdownRope;
	ParticleSystem bombExplosion;
	string levelText;
	public GUIStyle newLevelText;
	
	void Awake(){
		bombExplosion = GetComponentInChildren<ParticleSystem> ();
	}

	void Update () {
		if (levelTextFade >= 0) {
			levelTextFade -= Time.deltaTime;
		}
		if (KillTrigger.pauseTimer == false) {
			countdownTimer -= 1f/secondsTillDefeat*Time.fixedDeltaTime;
			countdownRope.fillAmount = countdownTimer;
		}
		if (countdownTimer <= 0.2f && stopPlaying == false) {
			countdownTimer = 0;
			bombExplosion.Play ();
			stopPlaying = true;
			StartCoroutine("WaitToRestart");
		}
		if (stopPlaying == true) {
			timeTillRestart -= Time.deltaTime;
		}
	}
	IEnumerator WaitToRestart() {
		yield return new WaitForSeconds(timeTillRestart);
		KillTrigger.pauseTimer = false;
		levelTextFade = 5f;
		RestartLevel.Restart ();
	}
	void OnGUI(){
		if (stopPlaying == true) {
			GUI.Label (new Rect (550, 100, 200, 100), "Restarting in: " + ((int)timeTillRestart + 1) + " seconds.");
		}
		if (levelTextFade >= 0) {
			KillTrigger.pauseTimer = false;
			if (LevelOn.levelOn == 1) {
				levelText = "LEVEL 1";
			} else if (LevelOn.levelOn == 2) {
				levelText = "LEVEL 2";
			} else if (LevelOn.levelOn == 3){
				levelText = "LEVEL 3";
			} else if (LevelOn.levelOn == 3){
				levelText = "GRATS YOU WIN!";
			}
			GUI.Label (new Rect (375, 50, 200, 100), levelText, newLevelText);

		}
	}
}
