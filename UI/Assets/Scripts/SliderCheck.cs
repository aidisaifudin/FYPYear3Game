using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderCheck : MonoBehaviour {
	public Slider sliderInstance;

	void Start() {
		sliderInstance.minValue = 0;
		sliderInstance.maxValue = 100;
		sliderInstance.wholeNumbers = true;
		sliderInstance.value = 100;
	}

	public void OnValueChanged(float value) {
		Debug.Log("Slider Value: " + value);
	}
}