using UnityEngine;
using System.Collections;

// Required components
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerControl : MonoBehaviour {
	[System.NonSerialized]					
	public float meshMoveSpeed = 4.0f;
	
	[System.NonSerialized]
	public float animSpeed = 1.5f; // Public setting for overall animator animation speed
	
	private Animator anim; // A reference to the animator on the character
	private AnimatorStateInfo currentBaseState; // A reference to the current state of the animator, used for base layer
	private AnimatorStateInfo weaponCurrentState; // A reference to the current state of the animator, used for layer 2

	static int reloadState = Animator.StringToHash("Weapon Layer.Reload"); // Used to check state for various actions to occur

	static int switchWeaponState = Animator.StringToHash("Weapon Layer.WeaponSwap");

	void Start() {
		// Initialising reference variables
		anim = GetComponent<Animator>();					  					
		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);
	}

	// Informs Unity that root motion is handled by the script as shown in Inspector
	void OnAnimatorMove() {
		if(anim) {
			Vector3 newPosition = transform.position;
			newPosition.z += anim.GetFloat("Speed")* meshMoveSpeed * Time.deltaTime;
			newPosition.x += anim.GetFloat("Direction") * meshMoveSpeed * Time.deltaTime;
			transform.position = newPosition;
		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal"); // Setup h variable as horizontal input axis
		float v = Input.GetAxis("Vertical"); // Setup v variable as vertical input axis
		anim.SetFloat("Speed", v); // Set animator's float parameter 'Speed' equal to the vertical input axis
		anim.SetFloat("Direction", h); // Set our animator's float parameter 'Direction' equal to the horizontal input axis
		anim.speed = animSpeed; // Set the speed of animator to the public variable 'animSpeed'
		//anim.SetLookAtWeight(lookWeight); // Set Look At Weight - amount to use look at IK vs using the head's animation
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0); // Set currentState variable to the current state of the Base Layer (0) of animation
		
		// Controls the movement speed
		if(v <= 0.0f) {
			meshMoveSpeed = 4;	
		} else {
			meshMoveSpeed = 6;
		}
		
		if(anim.layerCount ==2) {
			weaponCurrentState = anim.GetCurrentAnimatorStateInfo(1);	// set our weaponCurrentState variable to the current state of the second Layer (1) of animation
		}

		// Reload weapon state
		if(Input.GetButtonDown("Fire1")) {
			anim.SetBool("Reload", true);
		} else {
			anim.SetBool("Reload", false);
		}

		// Switch weapon state
		if(weaponCurrentState.fullPathHash != reloadState || currentBaseState.fullPathHash != switchWeaponState) {
			if(Input.GetButtonUp("Fire2")) {
				anim.SetBool("SwitchWeapon", true);
			}
		}

		if(weaponCurrentState.fullPathHash == switchWeaponState) {
			anim.SetBool("SwitchWeapon", false);
		}
	}
}