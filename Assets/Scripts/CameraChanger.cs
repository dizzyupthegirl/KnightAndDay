using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.I)) {
						this.gameObject.transform.position = new Vector3 (0.0f, 0.9f, 0.0f);
						this.gameObject.transform.rotation= new Quaternion(0.0f,0.0f,0.0f,0.0f);
				}
				
		if(Input.GetKeyDown(KeyCode.O)){
			this.gameObject.transform.position = new Vector3 (0.0f, 3.0f, -1.0f);
			this.gameObject.transform.rotation= new Quaternion(0.0f,0.0f,0.0f,0.0f);
		}
			
		if(Input.GetKeyDown(KeyCode.P)){
			this.gameObject.transform.position = new Vector3 (0.0f, 50.0f, 0.0f);
			this.gameObject.transform.rotation= new Quaternion(-90.0f,0.0f,0.0f,0.0f);
		}

		 

	}
}
