using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Spawner : MonoBehaviour {

	public GameObject ObjectToSpawn1, ObjectToSpawn2;
	public int totalToSpawn = 4;
	public float spawnInterval = 40.0f;
	public GUIText scoreText;
	public GUIText health;
	public GUIText bullets;
	private static int score = 0;
	private int lives;
	private int bulletsLeft;
	private int totalSpawn;
	public GameObject fader;
	public float speed;
	private Color faderColor;
	private static bool gameOver;
	public GUIText reloadMessage;
	public GUIText newWaveMessage;
	public bool printReload, won;
	public GameObject particles, particles2;
	private int winScore;
	public GameObject followCam, aboveCam;
	private KeepSelection selector;
	private int charactersBullets;
	public Image avatar;
	public Sprite blueSp, greenSp, purpleSp;
	public GameObject blue, greenPurple;
	private int selected;
	private static Sprite chosen;

	// Use this for initialization
	void Start () {


		scoreText.text = "Score: 0";
		particles.SetActive(false);
		particles2.SetActive(false);

		gameOver = false;
		faderColor = fader.renderer.material.color;
		reloadMessage.text = "";
		newWaveMessage.text = "";
		won = false;
		GameObject selectorObject = GameObject.FindWithTag ("Selection");
		if (selectorObject != null)
		{
			selector = selectorObject.GetComponent <KeepSelection>();
		}
		if (selector == null)
		{
			Debug.Log ("Cannot find 'KeepSelection' script");
		}
		if (Application.loadedLevelName == "MainScene") {

			score=0;
			gameOver=false;
			setKnight ();
		}

		updateScore (0);
		avatar.sprite = chosen;
		totalSpawn = totalToSpawn;
		winScore = (50 * totalSpawn*3) + (100 * totalSpawn * 3);
		StartCoroutine("SpawnRandom");
	}

	void setKnight(){
			if (selector != null) {
				selected=selector.getChosen();
				totalToSpawn=selector.getWaves();
			if (selected == 1) {

				lives = 10;
				charactersBullets = 10;
				bulletsLeft = charactersBullets;
				health.text = "Health: " + lives;
				bullets.text = "Bullets:" + bulletsLeft;
				Instantiate (blue);
				avatar.sprite=blueSp;

		
			}
			if (selected == 2) {

				lives = 20;
				charactersBullets = 10;
				bulletsLeft = charactersBullets;
				health.text = "Health: " + lives;
				bullets.text = "Bullets:" + bulletsLeft;
				Instantiate (greenPurple);
				avatar.sprite=greenSp;
			
			}
			if (selected == 3) {

				lives = 10;
				charactersBullets = 20;
				bulletsLeft = charactersBullets;
				health.text = "Health: " + lives;
				bullets.text = "Bullets:" + bulletsLeft;
				Instantiate (greenPurple);
				avatar.sprite=purpleSp;
			
			}
		} else {
			selected=2;
			lives = 20;
			charactersBullets = 10;
			bulletsLeft = charactersBullets;
			health.text = "Health: " + lives;
			bullets.text = "Bullets:" + bulletsLeft;
			Instantiate (greenPurple);
			avatar.sprite=greenSp;
			
		}
		chosen=avatar.sprite;
	
	}

	IEnumerator SpawnRandom(){
	while (totalToSpawn>0) {


			GameObject clone;
			clone = Instantiate(ObjectToSpawn1, randomPosition(), Quaternion.AngleAxis(Random.Range(-180, 180), Vector3.up)) as GameObject;
			clone = Instantiate(ObjectToSpawn2, randomPosition(), Quaternion.AngleAxis(Random.Range(-180, 180), Vector3.up)) as GameObject;
			clone = Instantiate(ObjectToSpawn1, randomPosition(), Quaternion.AngleAxis(Random.Range(-180, 180), Vector3.up)) as GameObject;
			clone = Instantiate(ObjectToSpawn2, randomPosition(), Quaternion.AngleAxis(Random.Range(-180, 180), Vector3.up)) as GameObject;
			totalToSpawn=totalToSpawn-1;
			StartCoroutine("newWave");
			yield return new WaitForSeconds(spawnInterval);
		
		}
	
	}

	Vector3 randomPosition(){
		Vector3 position = new Vector3(Random.Range(20.0f, 180.0f), 80, Random.Range(20.0f, 180.0f));
		return position;
	}

	public void updateScore(int points) {
		score=score+points;
		scoreText.text = "Score: " + score;
	
	}
	public void updateHealth(){
		lives--;
		health.text="Health: "+lives;
	}
	public void updateBullets(){
		bulletsLeft--;
		bullets.text="Bullets: "+bulletsLeft;
	}

	public bool hasBullets(){
	if (bulletsLeft > 0)
			return true;
		return false;
	
	}

	public void reloadGun(){
		bulletsLeft = charactersBullets;
		bullets.text="Bullets: "+bulletsLeft;
		printReload = false;
		particles.SetActive(false);
		particles2.SetActive(false);
	}
	public int getScore(){
		return score;
	
	}
	public int getSelected(){
		return selected;
	}
	IEnumerator reload() {
		reloadMessage.text="RELOAD NOW";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="RELOAD NOW";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="RELOAD NOW";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="RELOAD NOW";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="RELOAD NOW";
		yield return new WaitForSeconds(0.5f);
		reloadMessage.text="";
		yield return new WaitForSeconds(0.5f);
		
	}
	IEnumerator newWave() {
		int curWave = totalSpawn - totalToSpawn;
		newWaveMessage.text="WAVE "+curWave+"/"+totalSpawn+" INCOMING";
		yield return new WaitForSeconds(0.8f);
		newWaveMessage.text="";
		yield return new WaitForSeconds(0.5f);
		newWaveMessage.text="WAVE "+curWave+"/"+totalSpawn+" INCOMING";
		yield return new WaitForSeconds(0.8f);
		newWaveMessage.text="";
		yield return new WaitForSeconds(0.5f);
		newWaveMessage.text="WAVE "+curWave+"/"+totalSpawn+" INCOMING";
		yield return new WaitForSeconds(0.8f);
		newWaveMessage.text="";
		yield return new WaitForSeconds(0.5f);
		newWaveMessage.text="WAVE "+curWave+"/"+totalSpawn+" INCOMING";
		yield return new WaitForSeconds(0.8f);
		newWaveMessage.text="";
		yield return new WaitForSeconds(0.5f);
		
	}

	void checkGameWin(){
		if (winScore <=score) {
			won = true;
			gameOver=true;
		}
	
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.I)) {
			followCam.SetActive(true);
			aboveCam.SetActive(false);

			
		}
		
		if(Input.GetKeyDown(KeyCode.O)){
			followCam.SetActive(false);
			aboveCam.SetActive(true);

		}
		if (bulletsLeft != 0) {
			particles.SetActive(false);
			particles2.SetActive(false);
		}

		if (lives == 0) {
			gameOver = true;
		}
		checkGameWin ();
		if (bulletsLeft == 0 &&!printReload) {
			particles.SetActive(true);
			particles2.SetActive(true);
			StartCoroutine("reload");
			
			printReload=true;
		
		}
		if (Application.loadedLevelName == "MainScene") {
		if(won){	
			if (gameOver && faderColor.a + speed >= 0 && faderColor.a + speed <= 255) {
				faderColor.a += speed;
				fader.renderer.material.SetColor ("_Color", faderColor);}
			
			if ((fader.renderer.material.GetColor ("_Color").a + speed) >= 1.0f) {
				Application.LoadLevel ("Win");
			}
		} else{
				print ("Loading game over scene");
				if (gameOver && faderColor.a + speed >= 0 && faderColor.a + speed <= 255) {
					faderColor.a += speed;
					fader.renderer.material.SetColor ("_Color", faderColor);}
				
				if ((fader.renderer.material.GetColor ("_Color").a + speed) >= 1.0f) {
					Application.LoadLevel ("GameOver");
				}
			
			
			}

		}

		if (Application.loadedLevelName == "GameOver" || Application.loadedLevelName == "Win") {
			if (fader.renderer.material.GetColor ("_Color").a >= 0.0f) {
				faderColor.a -= speed;
				fader.renderer.material.SetColor ("_Color", faderColor);
			}
			if (fader.renderer.material.GetColor ("_Color").a <= 0.0f) {
				
				if ( Input.GetKeyDown ("r")) {
					Application.LoadLevel ("MainMenu");
				}
			}
		}	

	}

}
