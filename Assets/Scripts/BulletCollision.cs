using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {
	public GameObject explosionPrefab;
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


	void OnCollisionEnter(Collision collision) {
//		if (collision.gameObject.tag.Equals ("Enemy")) {
//			
//			Destroy (gameObject);
//			Destroy(collision.gameObject);		
//			gameController.updateScore(1);
//			ContactPoint contact = collision.contacts[0];
//			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
//			Vector3 pos = contact.point;
//			GameObject explosion = Instantiate(explosionPrefab, pos, rot) as GameObject;
//			Destroy( explosion, 3.0f );
//						
//		}
	}
}
