
using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {


	public string LevelName;
	public GameObject camera1;
	public GameObject camera2;
	public GameObject camera3;
	public int sound;
	public int diff1;
	public int language;
	public bool difficulty=false;
	public AdmobVNTIS_Interstitial x;



	void Start () {


		//PlayGamesPlatform.Activate();
		//Social.localUser.Authenticate((bool success) => {});
		camera1.SetActive(true);camera2.SetActive(false);camera3.SetActive(false);
		PlayerPrefs.HasKey ("Language");
		language = PlayerPrefs.GetInt ("Language");
		if(language==0)LanguageManager.LoadLanguageFile(Language.English);
		if(language==2)LanguageManager.LoadLanguageFile(Language.Russian);
		PlayerPrefs.HasKey ("Difficulty");
		diff1 = PlayerPrefs.GetInt ("Difficulty");
		sound = PlayerPrefs.GetInt("Sound");
		if (sound == 1) {AudioListener.volume = 0;}
		if (sound == 2) {AudioListener.volume = 1;}
		x = (AdmobVNTIS_Interstitial)GameObject.Find ("AdmobVNTISInterstitialObject").GetComponent ("AdmobVNTIS_Interstitial");
		if (x) {
			
			if (x.isInterstitialLoaded ()) {
				
				x.displayInterstitial ();
				
				x.loadInterstitial (); 
		
			}

		}
	}
	void Update()
	{	
		sound = PlayerPrefs.GetInt("Sound");
		if (sound == 1) {AudioListener.volume = 0;}
		if (sound == 2) {AudioListener.volume = 1;}
	}


}
