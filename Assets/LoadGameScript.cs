using UnityEngine;
using System.Collections;

public class LoadGameScript : MonoBehaviour {

	public void OnStartClick() {
		print ("Okay Button clicked");
		
		Application.LoadLevel(3);
		
	}
}
