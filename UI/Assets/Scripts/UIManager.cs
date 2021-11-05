using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public Animator moveRight;
	//public Animator settingsButton;

	public void StartGame() {
		SceneManager.LoadScene("Sprite Swap Button");
	}

	public void OpenSettings() {
		moveRight.SetBool ("isHidden", true);
		//settingsButton.SetBool ("isHidden", true);
	}
}