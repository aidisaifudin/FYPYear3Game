using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextCheck : MonoBehaviour {
	public string message;
	private Text textInstance;

	void Start() {
		textInstance = GetComponent<Text>();
	}
	
	void Update() {
		textInstance.text = message;
	}
}