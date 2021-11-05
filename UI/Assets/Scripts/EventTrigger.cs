using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour {
	public Image image;

	void Start() {
		image.color = Color.green;
	}

	public void OnCursorEnter() {
		image.color = Color.blue;
	}
	
	public void OnCursorExit() {
		image.color = Color.green;
	}
	
	public void OnCursorDown()
	{
		image.color = Color.red;
	}
	
	public void OnCursorUp()
	{
		image.color = Color.yellow;
	}
}