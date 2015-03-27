using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu1 : MonoBehaviour {
	private bool paused=false;
	public bool is_Pause=false;
	public string LevelName;
	private int language ;
	AdmobVNTIS_Banner_Advanced x;
	public void Start () 
	{
		Time.timeScale = 1;
		paused=false;
		PlayerPrefs.HasKey ("Language");
		language = PlayerPrefs.GetInt ("Language");
		if(language==0)LanguageManager.LoadLanguageFile(Language.English);
		if(language==2)LanguageManager.LoadLanguageFile(Language.Russian);
		x= (AdmobVNTIS_Banner_Advanced)GameObject.Find("AdmobVNTISBannerAdvancedObject").GetComponent("AdmobVNTIS_Banner_Advanced");
	}
	public void PauseClick(){
		if (!paused) 
		{
			paused = true;
			Time.timeScale = 0f;
			x.showAdview ();
		} 	
	}
	public void ResumeClick() 
	{	
		Time.timeScale = 1f;
		paused = false;	
	}
	public void MainMenuClick()
	{  	

		Time.timeScale = 1f;
		paused = false;
		Application.LoadLevel(LevelName);

			
	}	
	public void HideBanner(){
		x.hideAdview();
	}

}
