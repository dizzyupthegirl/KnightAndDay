using UnityEngine;
using System.Collections;

public class enemyDeath : MonoBehaviour {

	
	public int health;
	public GameObject explosion;
	public GameObject bulletExplosion;
	public int pointsWorth;
	private Spawner controller;
	private GameObject bulletExClone, enemEx;
	public Animation anim;
	private FollowScript follower;
	// Use this for initialization
	void Start () {
		
		bulletExClone = bulletExplosion;
		enemEx = explosion;
		getAnimations ();
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<Spawner>();
		}
		if (controller == null)
		{
			Debug.Log ("Cannot find 'Spawner' script");
		}

		follower = gameObject.GetComponent<FollowScript> ();

		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter(Collision collider){
		if (collider.collider.tag == "Player Bullets"){
			print ("hit: "+collider.collider.tag);
			Destroy (collider.gameObject);
			Object bul=Instantiate(bulletExClone, collider.gameObject.transform.position, collider.gameObject.transform.rotation);
			Destroy(bul, .5f);
			health = health-1;
			StartCoroutine( takeDamage() );
			if(health <= 0){
				StartCoroutine( death () );

			}

		}
	}


	void getAnimations(){
		anim = GetComponent<Animation> ();
		foreach (AnimationState state in anim) {
			state.speed = 0.5F;
			
			
		}
	}


	IEnumerator takeDamage(){
		follower.setDamaged (true);
		yield return new WaitForSeconds(1.0f);
		follower.setDamaged (false);
	}


	IEnumerator death(){
		follower.setDead ();
		yield return new WaitForSeconds(2.0f);

		print("Died!!");
		Destroy (this.gameObject);
		controller.updateScore(pointsWorth);
		Object enem=Instantiate (enemEx, transform.position, transform.rotation);
		Destroy(enem, 0.5f);
	
	}
}