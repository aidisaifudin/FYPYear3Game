using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedLayerControl : MonoBehaviour
{
	internal Animator animator; // Variable to store the animator component
	float h; // Variable to hold user horizontal input, turns
	float v; // Variable to hold user vertical input, forward/backward
	float rotSpeed  = 90.0f; // Rotation speed
	int j; // Variable to hold user jump input
	bool canJump = true; // Flag to control the jumping
	bool grounded = true; // Flag for in air or on ground 
	internal int windedState; // Need to coordinate with animator
	internal int layers; // Layers in the Animator

	void Start()
	{
		animator = GetComponent<Animator>(); // assign the Animator component
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
		v = Input.GetAxis("Vertical");
	}

	void FixedUpdate()
	{
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

		// Set the V Input parameter to the V axis value
		animator.SetFloat("Vertical", v);

		// rotate the character according to input and rotation speed
		transform.Rotate(new Vector3(0, h * Time.deltaTime * rotSpeed, 0));

		// Set the jumping parameter to the j value
		//animator.SetInteger ("Jump", j);
	}
}