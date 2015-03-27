using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour
{	
	private Animator anim;
	public  bool clear=false;
	private  int shield=0;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update(){

		if (shield ==1 ) {
		anim.SetBool ("shield", true);
		GameObject.Find ("Character").GetComponent<BoxCollider2D> ().isTrigger = true;
		GameObject.Find ("Character").GetComponent<CircleCollider2D> ().isTrigger = true;
		} 
		else {
			anim.SetBool("shield",false);
			GameObject.Find ("Character").GetComponent<BoxCollider2D> ().isTrigger = false;
			GameObject.Find ("Character").GetComponent<CircleCollider2D> ().isTrigger = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{ 
		if (col.gameObject.tag == "Enemy") {
						Collider2D[] cols = GetComponents<Collider2D> ();
						foreach (Collider2D c in cols) {
						if(shield <1){
					c.isTrigger = true;
					GameObject.Find ("Character").GetComponent<RM> ().isdead = true;
					anim.SetTrigger ("Die");}
			}} 
}
void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "ClearScreen") {
			Destroy(other.gameObject);
			clear=true;StartCoroutine (cw());	
		}
		if (other.gameObject.tag == "Shield") {
			if(shield==0){
				Destroy(other.gameObject);
				shield=shield+1;}
		}
		if (other.gameObject.tag == "Enemy" && shield>0) {
			StartCoroutine (dw());	
		}


}

IEnumerator cw()
{
System.DateTime timeToShowNextElement = System.DateTime.Now.AddSeconds(3f); 
while (System.DateTime.Now < timeToShowNextElement) { yield return null; }
clear=false;

}

IEnumerator dw()
{
anim.SetBool ("shield end", true);
System.DateTime timeToShowNextElement = System.DateTime.Now.AddSeconds(3f); 
while (System.DateTime.Now < timeToShowNextElement) { yield return null; }
		if(shield==1)shield=shield-1;
		anim.SetBool ("shield end", false);
}
}
	
	
	
	

