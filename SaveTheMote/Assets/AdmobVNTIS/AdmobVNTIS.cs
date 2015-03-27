using UnityEngine;
using System.Collections;

public class AdmobVNTIS : MonoBehaviour {
	public string PublisherID = "YOUR_AD_UNIT_ID";
	public string TestDeviceID = "";
	public AdSize AdvertisementSize = AdSize.BANNER;
	public Rules[] AdvertisemenRules;

	public enum AdSize{
		BANNER = 1,
		FULL_BANNER = 2,
		LEADERBOARD = 3,
		MEDIUM_RECTANGLE = 4,
		SMART_BANNER = 5,
		WIDE_SKYSCRAPER = 6
	};

	public enum Rules
	{
		ABOVE = 2,
		ALIGN_BASELINE = 4,
		ALIGN_BOTTOM = 8,
		ALIGN_END = 19,
		ALIGN_LEFT = 5,
		ALIGN_PARENT_BOTTOM = 12,
		ALIGN_PARENT_END = 21,
		ALIGN_PARENT_LEFT = 9,
		ALIGN_PARENT_RIGHT = 11,
		ALIGN_PARENT_START = 20,
		ALIGN_PARENT_TOP = 10,
		ALIGN_RIGHT = 7,
		ALIGN_START = 18, 	 
		ALIGN_TOP = 6,
		BELOW = 3,
		CENTER_HORIZONTAL = 14,
		CENTER_IN_PARENT = 13, 	
		CENTER_VERTICAL = 15,
		END_OF = 17,
		LEFT_OF = 0,
		RIGHT_OF = 1,
		START_OF = 16
	};

	void Start(){
		int[] rule = new int[AdvertisemenRules.Length + 1];
		
		rule[0] = (int)AdvertisementSize;

		if (rule.Length > 1) {
			for (int i = 0; i < AdvertisemenRules.Length; i++) {
				rule [i+1] = (int)AdvertisemenRules [i];
			}
		}

		AndroidJavaObject jo = new AndroidJavaObject ("admob.admob",PublisherID,TestDeviceID,rule);
	}
}
