using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeepSelection : MonoBehaviour {
	
	public Toggle blueToggle, greenToggle, purpleToggle;
	public Button letsGoButton;
	public static int chosenKnight;
	void Awake () {
		
		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		chosenKnight = 3;
		
	}
	
	void Update() {
		if (blueToggle.isOn || greenToggle.isOn || purpleToggle.isOn) {
			letsGoButton.enabled = true;
		} else {
			
			letsGoButton.enabled=false;
		}
		
	}
	
	public void onButtonClick(){
		if (blueToggle.isOn)
			chosenKnight = 1;
		if (greenToggle.isOn)
			chosenKnight = 2;
		if (purpleToggle.isOn)
			chosenKnight = 3;
		Application.LoadLevel(2);
		
	}
	
	public int getChosen(){
		return chosenKnight;
		
	}
}

