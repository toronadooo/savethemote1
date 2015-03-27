using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class chunkycontrol : MonoBehaviour 
{


	public float Force = 1f;
	private long extime;
	private float besttime;
	private float besttime1;
	private int sound;
	private int diff1;
	public bool is_Score=false;
	public bool is_Best=false;
	public bool is_BestHard=false;
	Text text ;

	private void Start()
	{
		Time.timeScale = 0f;
		besttime = PlayerPrefs.GetFloat ("BestTime");
		besttime1 = PlayerPrefs.GetFloat ("BestTime1");
		diff1 = PlayerPrefs.GetInt ("Difficulty");
		sound = PlayerPrefs.GetInt ("Sound");
		GameObject[] rubbishcreators;
		rubbishcreators = GameObject.FindGameObjectsWithTag ("RubbishCreator");
			if (sound == 1) {AudioListener.volume = 0;}
		if (sound == 2) {AudioListener.volume = 1;}
		if (diff1 == 1) {
			foreach (GameObject RubbishCreator in rubbishcreators) {
				RubbishCreator.GetComponent<BackgroundPropSpawner> ().enabled = true;
				RubbishCreator.GetComponent<Hardcorespawn> ().enabled = false;
			}
		}
		if (diff1 == 2) {
			foreach (GameObject RubbishCreator in rubbishcreators) {
				RubbishCreator.GetComponent<BackgroundPropSpawner> ().enabled = false;
				RubbishCreator.GetComponent<Hardcorespawn> ().enabled = true;
			}
		}
	}
	public void StartClick()
	{
		Time.timeScale = 1f;
	}
	private void Update()
	{
		if ((Input.GetKey (KeyCode.Space)) || (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began)) 
		{
			rigidbody2D.AddForce (new Vector2 (0f,Force * Time.timeScale));				
		}
		extime = (int)Time.timeSinceLevelLoad;
		if (is_Score) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Survive" ) +" " + extime +" " + LanguageManager.GetText ("sec");}
		besttime = PlayerPrefs.GetFloat ("BestTime");
		besttime1 = PlayerPrefs.GetFloat ("BestTime1");
		if (sound == 1) {AudioListener.volume = 0;}
		if (sound == 2) {AudioListener.volume = 1;}
		if (diff1 == 1) {
		SetHighTime ();
			if (is_Best) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("BestSurvive") + " " + besttime + " " + LanguageManager.GetText ("sec");}
			if (Social.localUser.authenticated) {
				if (extime > 30) {Social.ReportProgress ("CgkIl9yixeMPEAIQAQ", 100.0f, (bool success) => {});}
				if (extime > 60) {Social.ReportProgress (" CgkIl9yixeMPEAIQAg", 100.0f, (bool success) => {});}
				if (extime > 120) {Social.ReportProgress ("CgkIl9yixeMPEAIQAw", 100.0f, (bool success) => {});}
				if (extime > 180) {Social.ReportProgress ("CgkIl9yixeMPEAIQBA", 100.0f, (bool success) => {});}
				if (extime > 240) {Social.ReportProgress ("CgkIl9yixeMPEAIQBQ", 100.0f, (bool success) => {});}
				if (extime > 480) {Social.ReportProgress ("CgkIl9yixeMPEAIQBg", 100.0f, (bool success) => {});}
			}				
		}
		if (diff1 == 2) {
			SetHighTime1 ();
			if (is_BestHard) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("BestSurvive") + " " + besttime1 + " " + LanguageManager.GetText ("sec");}
				if (Social.localUser.authenticated) {			
				if (extime > 10) {Social.ReportProgress ("CgkIl9yixeMPEAIQCA", 100.0f, (bool success) => {});}
				if (extime > 20) {Social.ReportProgress ("CgkIl9yixeMPEAIQCQ", 100.0f, (bool success) => {});}
				if (extime > 30) {Social.ReportProgress ("CgkIl9yixeMPEAIQCg", 100.0f, (bool success) => {});}
				if (extime > 40) {Social.ReportProgress ("CgkIl9yixeMPEAIQCw", 100.0f, (bool success) => {});}
				if (extime > 50) {Social.ReportProgress ("CgkIl9yixeMPEAIQDA", 100.0f, (bool success) => {});}
				if (extime > 60) {Social.ReportProgress ("CgkIl9yixeMPEAIQDQ", 100.0f, (bool success) => {});}
				if (extime > 90) {Social.ReportProgress ("CgkIl9yixeMPEAIQDg", 100.0f, (bool success) => {});}
				if (extime > 120) {Social.ReportProgress ("CgkIl9yixeMPEAIQEg", 100.0f, (bool success) => {});}
						}
				}
	}	
	private void SetHighTime()
	{
		if (Social.localUser.authenticated && GameObject.Find ("Character").GetComponent<RM> ().isdead == true) {Social.ReportScore(extime,"CgkIl9yixeMPEAIQDw", (bool success) =>{});}
		if (extime > besttime) {PlayerPrefs.SetFloat("BestTime",extime);}
	}
	private void SetHighTime1()
	{
		if (Social.localUser.authenticated && GameObject.Find ("Character").GetComponent<RM> ().isdead == true){Social.ReportScore(extime,"CgkIl9yixeMPEAIQEA", (bool success) =>{});}
		if (extime > besttime1) {PlayerPrefs.SetFloat("BestTime1",extime);}
	}
}