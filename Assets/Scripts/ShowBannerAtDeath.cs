using UnityEngine;
using System.Collections;

public class ShowBannerAtDeath : MonoBehaviour {
	AdmobVNTIS_Banner_Advanced x;
	// Use this for initialization
	void Start () {
		x= (AdmobVNTIS_Banner_Advanced)GameObject.Find("AdmobVNTISBannerAdvancedObject").GetComponent("AdmobVNTIS_Banner_Advanced");
		x.showAdview ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
