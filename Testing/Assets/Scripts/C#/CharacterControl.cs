using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
	internal Animator animator; // var to store the animator component
	private float h; // variable to hold user horizontal input, turns
	private float v; // variable to hold user vertical input, forward/backward
	private float rotSpeed  = 90.0f; //rotation speed
	private float j; // variable to hold user jump input
	private bool canJump = true; //flag to control the jumping
	private bool grounded = true; // flag for in air or on ground

	void Start()
	{
		animator = GetComponent<Animator>(); // assign the Animator component
	}

	void Update()
	{
		// Get Input each frame and assign it to the variables
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		j = Input.GetAxis("Jump");
		//print (j);
	}

	void FixedUpdate()
	{
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

		// Set the V Input parameter to the V axis value
		animator.SetFloat("Vertical", v);

		// rotate the character according to input and rotation speed
		transform.Rotate(new Vector3(0, h * Time.deltaTime * rotSpeed, 0));

		// Set the Turning parameter to the H axis value
		animator.SetFloat("Horizontal", h);

		// Set the jumping parameter to the j value
		//animator.SetInteger ("Jump", j);
		if (stateInfo.IsName("Base Layer.Idle"))
		{
			// Set the jumping parameter to the j value
			if (canJump && grounded && j == 1) GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
			ProcessJump();
		}
	}

	IEnumerator ProcessJump()
	{
		// if the player pressed jump and it can jump
		if (j == 1 && canJump == true && grounded)
		{
			// Trigger the jump
			animator.SetBool("Up", true);
			// Prevent more jumps
			grounded = false;// Jump is in progress
			yield return null;
			animator.SetBool("Up", false);
			canJump = false; // a jump is in progress
		}
		else if (j == 0)
		{
			yield return null;
			canJump = true; // Reset jump flag
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		grounded = true;
	}
}