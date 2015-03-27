using UnityEngine;
using System.Collections;

public class GroundChk : MonoBehaviour {
	private Animator anim;
	private bool isGrounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	void Start () {
		anim = GetComponent<Animator>();
	}
	void Update () {

		if ((Input.GetKey (KeyCode.Space)) || (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began)) 
		{
			anim.SetBool ("ground", false);
			anim.SetBool ("jump", true);
		}
		else anim.SetBool ("jump", false);
	}
	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
		anim.SetBool ("ground", isGrounded);
		if (!isGrounded)return;	
	}
}
