using UnityEngine;
using System.Collections;

public class ExitBackKey : MonoBehaviour {
		void Update () {
			if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		}
	}
