using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class functions : MonoBehaviour {
	public GameObject camera1;
	public GameObject camera2;
	public GameObject camera3;
	public int language ;

	public void Start(){
		PlayerPrefs.HasKey ("Language");
		language = PlayerPrefs.GetInt ("Language");
	}
	public void AchClick(){Social.ShowAchievementsUI ();
	}
	public void LeadClick(){Social.ShowLeaderboardUI();
	}
	public void ExitClick(){Application.Quit();
	}

	public void NGClick(){
				camera1.SetActive (false);camera3.SetActive (true);
				if (Social.localUser.authenticated) {
			Social.ReportProgress ("CgkIl9yixeMPEAIQAA", 100.0f, (bool success) => {});
				}
		}
	public void RusClick(){
		LanguageManager.LoadLanguageFile(Language.Russian);language=2;PlayerPrefs.SetInt("Language",language);
	}
	public void EngClick(){
		LanguageManager.LoadLanguageFile(Language.English);language=0;PlayerPrefs.SetInt("Language",language);
	}
	public void GPSIn(){
		Social.localUser.Authenticate((bool success) =>{});

	}
	public void GPSOut(){
	
		((PlayGamesPlatform)Social.Active).SignOut();
	}

	void Update(){
		PlayerPrefs.HasKey ("Language");
		language = PlayerPrefs.GetInt ("Language");
		if (Social.localUser.authenticated) {
			GameObject.Find ("GPSIn").GetComponent<Image> ().enabled = false;
			GameObject.Find("GPSOut").GetComponent<Image> ().enabled=true;
				}
		else
		{
			GameObject.Find ("GPSIn").GetComponent<Image> ().enabled = true;
			GameObject.Find("GPSOut").GetComponent<Image> ().enabled=false;
		}
	}
	
	
}
