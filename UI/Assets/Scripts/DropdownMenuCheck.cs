using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropdownMenuCheck : MonoBehaviour {
	public Dropdown dropdownMenuInstance;

	public void OnValueChanged() {
		Debug.Log("Dropdown Text: " + dropdownMenuInstance.options[dropdownMenuInstance.value].text);
	}
}