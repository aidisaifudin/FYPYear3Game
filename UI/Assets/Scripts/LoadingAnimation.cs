using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingAnimation : MonoBehaviour {
	Animator loadingAnimation;

	// Get the animator component
	void Awake() {
		loadingAnimation = GetComponent<Animator>();
	}
	
	// Start the loading animation
	void Start() {
		loadingAnimation.SetBool("Loading", true);
		StartCoroutine(LoadLevel());
	}

	// Simple coroutine to delay for 5 seconds and then load the level
	IEnumerator LoadLevel() {
		for(int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(1); 
		}

		loadingAnimation.SetBool("Loading", false);
		//SceneManager.LoadScene("Play");
	}
}