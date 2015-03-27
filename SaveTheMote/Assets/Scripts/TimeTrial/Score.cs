using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {

		
		Text text;
		
		void Start () {
			
			
		}
		
		void Update () {
			text = GetComponent<Text> ();
			text.text = ": "+StartScore.score;
		}
		
		
	}
