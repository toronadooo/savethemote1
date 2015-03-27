using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestScript : MonoBehaviour 
{

	private string[] selections;
	public int language ;
	public bool  is_Play=false;
	public bool is_Leaderboard=false;
	public bool is_Achievements=false;
	public bool is_Options=false;
	public bool is_Exit=false;
	public bool is_Back=false;
	public bool is_Sound=false;
	public bool is_GPS=false;
	public bool is_Choose=false;
	public bool is_Normal=false;
	public bool is_Hardcore=false;
	public bool is_Diff=false;
	public bool is_Resume=false;
	public bool is_MainM=false;
	public bool is_Tap = false;
	public bool is_Dead = false;
	public bool is_NM = false;
	public bool is_HM = false;
	public bool is_Mode = false;
	public bool is_TT = false;
	public bool is_TapEat = false;
	public bool is_Eat = false;
	public bool is_YouEat = false;
	public bool is_Fed = false;
	public bool is_Time = false;
	public bool is_Dodge = false;
	public bool is_Collect = false;
	Text text;

	void Start()
	{
		PlayerPrefs.HasKey ("Language");
		language = PlayerPrefs.GetInt ("Language");
		if(language==0)LanguageManager.LoadLanguageFile(Language.English);
		if(language==2)LanguageManager.LoadLanguageFile(Language.Russian);
	}
	void Update(){
		if (is_Exit) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Exit");}
		if (is_Options) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Options");}
		if (is_Achievements) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Achievements");}
		if (is_Leaderboard) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Leaderboard");}
		if (is_Play){text = GetComponent<Text> ();text.text =  LanguageManager.GetText("NewGame"); }
		if (is_Back) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Back");}
		if (is_Choose) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Choose");}
		if (is_GPS) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("GPS");}
		if (is_Sound) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Sound");}
		if (is_Normal) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Normal");}
		if (is_Hardcore) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Hardcore");}
		if (is_Diff) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("Diff");}
		if (is_Resume) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Resume");}
		if (is_MainM) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("MainMenu");}
		if (is_Tap) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Taptofly");}
		if (is_Dead) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("MoteIsDead");}
		if (is_Mode) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Mode");}
		if (is_TT) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("TimeTrial");}
		if (is_TapEat) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("TaptoEat");}
		if (is_Eat) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Eat");}
		if (is_YouEat) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("YouEat");}
		if (is_Fed) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("MoteFed");}
		if (is_Time) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("TimeT");}
		if (is_Dodge) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Dodge");}
		if (is_Collect) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Collect");}
	}


}
