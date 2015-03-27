using UnityEngine;
using System.Collections;

public class CharacterTTDie : MonoBehaviour {

	

	void OnTriggerEnter2D(Collider2D other) {
				if (other.gameObject.tag == "Enemy") StartScore.score += 1;
		Destroy (other.gameObject);
	}
	
}





