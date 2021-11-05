using UnityEngine;
using System.Collections;

public class ButtonCheck : MonoBehaviour {
	public void OnClick() {
		Debug.Log("On Click");
	}

	public void OnOver() {
		Debug.Log("On Over");
	}

	public void OnExit() {
		Debug.Log("On Exit");
	}
}