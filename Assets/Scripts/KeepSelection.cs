using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeepSelection : MonoBehaviour {
	
	public Toggle blueToggle, greenToggle, purpleToggle;
	public Button letsGoButton;
	public static int chosenKnight;
	public static int numWaves;
	public Slider waves;
	public Text waveText;
	void Awake () {
		
		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		chosenKnight = 3;
		numWaves =(int) waves.minValue;
		waveText.text = "Number of Waves: "+numWaves;
		
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

	public void onSliderChange(){
		numWaves = (int)waves.value;
		waveText.text = "Number of Waves: "+numWaves;
	
	}
	
	public int getChosen(){
		return chosenKnight;
		
	}
	public int getWaves(){
		return numWaves;
	
	}
}

