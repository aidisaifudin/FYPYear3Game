using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class ToggleCheck : MonoBehaviour {
	ToggleGroup toggleGroupInstance;

	public Toggle currentSelection{
		get {return toggleGroupInstance.ActiveToggles().FirstOrDefault();}
	}

	void Start() {
		toggleGroupInstance = GetComponent<ToggleGroup>();
		Debug.Log(currentSelection.name + " Selected");

		SelectToggle(2);
	}
	
	public void SelectToggle(int id){
		var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle>();
		toggles[id].isOn = true;
	}
}