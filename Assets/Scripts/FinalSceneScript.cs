using UnityEngine;
using System.Collections;

public class FinalSceneScript : MonoBehaviour {
	private Spawner gameController;
	public GUIText score;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Spawner>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'Spawner' script");
			score.text = "";
		} else {
			score.text = "Score: " + gameController.getScore ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown ("r")) {
			Application.LoadLevel ("MainMenu");
		}


	}
}
