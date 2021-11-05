using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentTypeControl : MonoBehaviour {
	public InputField inputField;

	public void Toggle() {
		if(inputField.contentType == InputField.ContentType.Alphanumeric) {
			inputField.contentType = InputField.ContentType.Password;
			inputField.ForceLabelUpdate();
		} else {
			inputField.contentType = InputField.ContentType.Alphanumeric;
			inputField.ForceLabelUpdate();
		}
	}
}