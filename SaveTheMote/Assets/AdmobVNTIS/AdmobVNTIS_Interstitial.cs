using UnityEngine;
using System.Collections;

public class AdmobVNTIS_Interstitial : MonoBehaviour {

	public string PublisherID = "YOUR_AD_UNIT_ID";
	public string TestDeviceID = "";
	public bool ShowInterstitialOnLoad = false;

	private static AndroidJavaObject jo;
	//bool displayed = false;

	// Dont destroy on load and prevent duplicate
	private static bool created = false;
	//private static bool paused = false;
	void Awake() {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		}
	}
	//


	void Start () {
		initializeInterstitial ();
	}

	void initializeInterstitial(){
		jo = new AndroidJavaObject ("admob.admob",PublisherID,TestDeviceID,ShowInterstitialOnLoad);
	}

	/// <summary>
	/// Load the interstitial.
	/// </summary>
	public void loadInterstitial(){
		jo.Call ("loadInterstitial");
	}

	/// <summary>
	/// Display the interstitial.
	/// </summary>
	public void displayInterstitial(){
		jo.Call ("displayInterstitial");
	}

	/// <summary>
	/// Is the interstitial loaded?
	/// </summary>
	/// <returns><c>true</c>, if the interstitial is loaded, <c>false</c> otherwise.</returns>
	public bool isInterstitialLoaded(){
		return jo.Call<bool>("isInterstitialLoaded");
	}
}
