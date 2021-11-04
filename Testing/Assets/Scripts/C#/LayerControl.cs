using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerControl : MonoBehaviour
{
	internal Animator animator; // Variable to store the animator component
	float h; // Variable to hold user horizontal input, turns
	float v; // Variable to hold user vertical input, forward/backward
	float rotSpeed  = 90.0f; // Rotation speed
	float j; // Variable to hold user jump input
	bool canJump = true; // Flag to control the jumping
	bool grounded = true; // Flag for in air or on ground 
	internal int windedState; // Need to coordinate with animator
	internal int layers; // Layers in the Animator

	void Start()
    {
		animator = GetComponent<Animator>(); // Assign the Animator component
		layers = animator.layerCount;
		if (layers >= 2)
		{
			for (int i = 1; i < layers; i++ ) {
				animator.SetLayerWeight(i, 1);
			}
		}
	}

	void Update()
    {
		// Get Input each frame and assign it to the variables
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		j = Input.GetAxis("Jump");

		if (Input.GetButtonDown("Fire1"))
		{ // && animator.layerCount >= 2){
			animator.SetBool("Nod", true);
		}
		else
			animator.SetBool("Nod", false);

		if (Input.GetButtonDown("Fire2"))
		{
			animator.SetBool("Talk", !animator.GetBool("Talk"));
		}

		if (Input.GetButtonDown("Fire3"))
		{
			animator.SetBool("Wave", !animator.GetBool("Wave"));
		}
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
		// If the player pressed jump and it can jump
		if (j == 1 && canJump == true && grounded)
		{
			// Trigger the jump
			animator.SetBool("Up", true);
			// Prevent more jumps
			grounded = false; // Jump in progress
			yield return null;
			animator.SetBool("Up", false);
			canJump = false; // Jump not in progress
		}
		else if (j == 0)
		{
			yield return null;
			canJump = true; // Reset the jump flag
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		grounded = true;
	}
}