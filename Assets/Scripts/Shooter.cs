using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Shooter : MonoBehaviour {
	public GameObject projectile;
	public float speed=20.0f;
	public AudioClip shoot;
	private Spawner controller;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<Spawner>();
		}
		if (controller == null)
		{
			Debug.Log ("Cannot find 'Spawner' script");
		}
	
	}
	

	void Update() {
		if (Input.GetButtonDown("Fire1") && controller.hasBullets()) {
			controller.updateBullets();
			audio.PlayOneShot(shoot, 0.7F);
			GameObject clone;
			Vector3 spawn=transform.position-new Vector3(0.0f,0.3f,0.0f);
			clone = Instantiate(projectile,spawn , transform.rotation) as GameObject;
			clone.rigidbody.velocity = transform.TransformDirection(Vector3.forward * speed);
			Destroy(clone, 6.0f);
		}
	}
}
