using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class RM : MonoBehaviour {
	public bool isdead=false;
	public string LevelName;
	private int diff;
	private float Kamikaze;
	private float Kamikaze1;
	public bool is_Restart;
	Text text;
	public GameObject ept;
	public GameObject eptScore;
	public GameObject PauseB;

	void Start(){
		Kamikaze = PlayerPrefs.GetFloat ("Kamikaze");
		diff = PlayerPrefs.GetInt ("Difficulty");
		Kamikaze1=Kamikaze+1;
		}

	void Update () {

		if (isdead) {
		Time.timeScale = 0f;
		eptScore.SetActive(false);
		ept.SetActive(true);
		PauseB.SetActive(false);
		if (diff == 1) {
		GameObject.Find ("EndBestNorm").GetComponent<Text> ().enabled = true;
		GameObject.Find ("NM").GetComponent<Text> ().enabled = true;
		}
		if (diff == 2) {
		GameObject.Find ("EndBestHard").GetComponent<Text> ().enabled = true;
		GameObject.Find ("HM").GetComponent<Text> ().enabled = true;
			}
		}
		KamikazeDie ();
		if (Social.localUser.authenticated) {
			if (Kamikaze > 99) {Social.ReportProgress ("CgkIl9yixeMPEAIQBw", 100.0f, (bool success) =>{});}}
		if (is_Restart) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Restart" ); }

	}
	private void KamikazeDie(){
		if (Kamikaze1 > Kamikaze) {
			PlayerPrefs.SetFloat("Kamikaze",Kamikaze);
		}
	}
	public void RestartClick(){
		Application.LoadLevel(1);isdead=false;Time.timeScale=1f;
		}


}