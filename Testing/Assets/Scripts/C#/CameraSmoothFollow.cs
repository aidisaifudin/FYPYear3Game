using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour {
	public Transform target; // Target following
	public float distance = 3.0f; // Target distance along x-z plane
	public float height = 1.0f; // Camera height above target
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;

	void LateUpdate() {
		if(!target)
			return;
		
		// Calculate current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		// Dampen rotation about the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Dampen height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert angle into rotation
		Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
		
		// Set position of camera on x-z plane to distance behind target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		
		// Set camera height
		Vector3 temp = transform.position;
		temp.y = currentHeight;
		transform.position = temp;
		
		// Look at target
		transform.LookAt(target);
	}
}