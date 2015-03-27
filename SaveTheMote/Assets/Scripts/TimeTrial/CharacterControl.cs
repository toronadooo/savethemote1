using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour {
		public float Force = 1f;
		private long extime;
		private float besttime2;
		private int sound;
		public bool is_Eat=false;
		public bool is_BestTimeTrial=false;
		public BoxCollider2D box;
		Text text ;
		
		private void Start()
		{
			Time.timeScale = 0f;
			besttime2 = PlayerPrefs.GetFloat ("BestTime3");
			sound = PlayerPrefs.GetInt ("Sound");
			GameObject[] rubbishcreators;
			rubbishcreators = GameObject.FindGameObjectsWithTag ("RubbishCreator");
			if (sound == 1) {AudioListener.volume = 0;}
			if (sound == 2) {AudioListener.volume = 1;}
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
			
			if (is_Eat) {text = GetComponent<Text> ();text.text =  LanguageManager.GetText ("Eat") +" " +StartScore.score;}
			besttime2 = PlayerPrefs.GetFloat ("BestTime3");
			if (sound == 1) {AudioListener.volume = 0;}
			if (sound == 2) {AudioListener.volume = 1;}
			SetHighTime2 ();
			if (is_BestTimeTrial) {text = GetComponent<Text> ();text.text = LanguageManager.GetText ("BestEat") + " " + besttime2;}
			if (Social.localUser.authenticated) {			
			if (StartScore.score > 30) {Social.ReportProgress ("CgkIl9yixeMPEAIQEw", 100.0f, (bool success) => {});}
			if (StartScore.score > 40) {Social.ReportProgress ("CgkIl9yixeMPEAIQFA", 100.0f, (bool success) => {});}
			if (StartScore.score > 50) {Social.ReportProgress ("CgkIl9yixeMPEAIQFQ", 100.0f, (bool success) => {});}
			if (StartScore.score > 60) {Social.ReportProgress ("CgkIl9yixeMPEAIQFg", 100.0f, (bool success) => {});}
			if (StartScore.score > 90) {Social.ReportProgress ("CgkIl9yixeMPEAIQFw", 100.0f, (bool success) => {});}
					
				}
		}	
		private void SetHighTime2()
		{
		if (Social.localUser.authenticated && GameObject.Find ("Character").GetComponent<RMTT> ().isdead == true) {Social.ReportScore(StartScore.score,"CgkIl9yixeMPEAIQEQ", (bool success) =>{});}
		if (StartScore.score > besttime2) {PlayerPrefs.SetFloat("BestTime3",StartScore.score);}
		}
	}