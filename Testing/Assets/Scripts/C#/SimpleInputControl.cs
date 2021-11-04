using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInputControl : MonoBehaviour
{
	internal Animator animator; // Variable to store the animator component 
	float v; // Variable to hold user vertical input
	float h; // Variable to hold user horizontal input
	float rotateFactor = 90.0f;
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
		v = Input.GetAxis("Vertical");
		h = Input.GetAxis("Horizontal");
	}

	void FixedUpdate()
	{
		// Set the V Input parameter to the V axis value
		animator.SetFloat("Vertical", v);

		// Rotate the character according to input and rotation speed
		transform.Rotate(new Vector3(0, h * Time.deltaTime * rotateFactor, 0));

	}
}