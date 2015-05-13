using UnityEngine;
using System.Collections;

public class OnTriggerReloadScript : MonoBehaviour {
	private Spawner gameController;

	void Start(){
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Spawner>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'Spawner' script");
		}
	}


	void OnTriggerEnter(Collider other) {
		print ("Trigger Enter " + other.gameObject.name);
		if (other.gameObject.tag=="Player") {
			gameController.reloadGun();
		}
	}
}
