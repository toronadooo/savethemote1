using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class RMTT : MonoBehaviour {
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
	public GameObject SliderEnd;
	public int limittime;
	public int ltime;         
	public int ltimeold=0;
	public Slider slider; 
	
	void Start(){
		Kamikaze = PlayerPrefs.GetFloat ("Kamikaze");
		Kamikaze1=Kamikaze+1;
	}
	
	void Update () {
		limittime =90 - (int)Time.timeSinceLevelLoad;
		ltime =(int)Time.timeSinceLevelLoad;
		if (ltime != ltimeold ) {
			slider.value -= 1;
			ltimeold = ltime;
		}
		if (limittime == 0) {isdead = true;}
		if (isdead) {
			Time.timeScale = 0f;
			eptScore.SetActive(false);
			ept.SetActive(true);
			PauseB.SetActive(false);
			SliderEnd.SetActive(false);
			GameObject.Find ("EndBestTimeTrial").GetComponent<Text> ().enabled = true;
			GameObject.Find ("TT").GetComponent<Text> ().enabled = true;
		}
		KamikazeDie ();
		if (Social.localUser.authenticated) {
		if (Kamikaze > 99) {Social.ReportProgress ("CgkIl9yixeMPEAIQBw", 100.0f, (bool success) =>{});}}
		if (is_Restart) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Restart"); }
		
	}
	private void KamikazeDie(){
		if (Kamikaze1 > Kamikaze) {
			PlayerPrefs.SetFloat("Kamikaze",Kamikaze);
		}
	}
	public void RestartClick(){
		Application.LoadLevel(2);isdead=false;Time.timeScale=1f;
	}
	
	
}