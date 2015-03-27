using UnityEngine;
using System.Collections;

public class funcdiff : MonoBehaviour {
	public int diff1;
	public GameObject camera1;
	public GameObject camera2;
	public GameObject camera3;
	// Use this for initialization
	void Start () {
		PlayerPrefs.HasKey ("Difficulty");
		diff1 = PlayerPrefs.GetInt ("Difficulty");
	}
	
	public void NormalClick(){
		
		diff1 =1;PlayerPrefs.SetInt ("Difficulty",1);Application.LoadLevel ("myscene");
	}
	public void HardClick(){
		
		diff1=2;PlayerPrefs.SetInt("Difficulty",2);Application.LoadLevel("myscene");
	}
	public void TimeTrialClick(){
		
		diff1 =1;PlayerPrefs.SetInt ("Difficulty",3);Application.LoadLevel ("myscene3");
	}
	public void BackOpt(){
			camera2.SetActive (false);camera1.SetActive (true);
	}
	public void BackDiff(){
			camera3.SetActive (false);camera1.SetActive (true);

	}
	public void Opt(){
				camera1.SetActive(false);camera2.SetActive (true);

	}
}
