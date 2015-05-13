using UnityEngine;

public class FollowScript : MonoBehaviour {
	Transform target;   
	public float distance;     
	public float height;        
	public float positionDamping;   
	public float rotationDamping;   
	Rigidbody rBody;
	bool damaged,dead, playingAnim;
	GameObject targetObject;
	public Animation anim;
	private float health;
	private Spawner controller;
	float timeElapsed;
	bool stopMoving=false;
	void Start(){
		distance = 3;
		height = 1;
		positionDamping = 4;
		rotationDamping = 150;
		targetObject = GameObject.FindWithTag ("Player");
		getAnimations ();
		health = 3;
		damaged = false;
		dead=false;
		playingAnim = false;
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
	void Awake() {
		rBody = GetComponent<Rigidbody>();
	}
	


		
	
	

	public void FixedUpdate () {
		timeElapsed = timeElapsed + Time.deltaTime;

		target = targetObject.transform;
		float distance = Vector3.Distance (target.position, rBody.position);
		if (!playingAnim) {
			if (damaged) {
				anim.CrossFade ("Damage");
				playingAnim = true;
			} else if (dead) {
				anim.CrossFade ("Dead");
				playingAnim = true;
			} else if (distance < 4) {
				anim.CrossFade ("Attack");
				stopMoving=true;
				if(timeElapsed>3.0f){
					controller.updateHealth();
					timeElapsed=0.0f;
				}
	
			} else {
				stopMoving=false;
				anim.CrossFade ("Walk");
		
			}
		}
		if (!stopMoving) {
			Vector3 targetPosition = target.position + target.up * height - target.forward * distance;
	
			Quaternion targetRotation = Quaternion.LookRotation (target.position - transform.position, target.up);

			rBody.position = Vector3.MoveTowards (rBody.position, targetPosition, positionDamping * Time.deltaTime);
			rBody.rotation = Quaternion.RotateTowards (rBody.rotation, targetRotation, rotationDamping * Time.deltaTime);
		}

	}

	void getAnimations(){
		anim = GetComponent<Animation> ();
		foreach (AnimationState state in anim) {
			state.speed = 0.5F;
			
			
		}
	}

	public void setDamaged(bool isDamaged){
		damaged=isDamaged;
		if (!damaged) {
			playingAnim = false;
		}
	}
	public void setDead(){
		dead=true;
	}
		
		
		
	}