using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollBarCheck : MonoBehaviour {
	public Scrollbar scrollbarInstance;

	void Start() {
		scrollbarInstance.value = 0;
	}

	public void OnValueChanged(float value) {
		Debug.Log("Scrollbar Value: " + value);
	}
}