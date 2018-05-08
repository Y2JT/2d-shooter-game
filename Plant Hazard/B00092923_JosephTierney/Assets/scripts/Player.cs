using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);

	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	private PlayerDisplay playerDisplay;
	private int lives = 3;

	// Use this for initialization
	void Start () {
		playerDisplay = GetComponent<PlayerDisplay> ();
		playerDisplay.UpdateLivesImage (lives);
	}
	
	// Update is called once per frame
	void Update () {

		string livesMessage = "Lives = " + lives;

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY);

		//Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		//crtl + arrow

		if (shoot){
			Weapon weapon = GetComponent<Weapon>();
			if (weapon != null){
				//false because the player is not an enemy
				weapon.Attack(false);
				Sounds.Instance.MakePlayerShotSound();
			}//end inner if
		}//end if

		//if all enemies with tag enemy are destroyed, load next scene (level 2 load)
		if (GameObject.FindWithTag ("Enemy") == null) {
			int i = Application.loadedLevel;
			Application.LoadLevel(i + 1);
			lives = 3;
		}//end if

		//press esc key to end program
		if (Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}//end if
			
	}
		
	void FixedUpdate(){
		if (rigidbodyComponent == null)
			rigidbodyComponent = GetComponent<Rigidbody2D> ();

		rigidbodyComponent.velocity = movement;
	}

	void OnTriggerEnter2D(Collider2D hit){
		//if player is hit by shot, call LoseLife() method, call MakeDieSound() in Sound script
		if (hit.CompareTag ("enemyShot")) {
			LoseLife ();
			Sounds.Instance.MakeDieSound();
		}//end if
			
	}

	void OnCollisionEnter2D(Collision2D collision){
		bool damagePlayer = false;

		//Collision with enemy
		Enemy enemy = collision.gameObject.GetComponent<Enemy>();
		if (enemy != null){
			//Kill the enemy
			//Health enemyHealth = enemy.GetComponent<Health>();
			//if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			LoseLife();
			Sounds.Instance.MakeDieSound();
			damagePlayer = true;
		}//end if

		//Damage the player
		if (damagePlayer){
			Health playerHealth = this.GetComponent<Health>();
			if (playerHealth != null) playerHealth.Damage(1);
		}//end if
			
	}

	//void OnDestroy(){
	//	Application.LoadLevel ("scene1_gameover");
	//}

	private void LoseLife(){
		lives--;
		if (lives < 1) {
			Application.LoadLevel ("scene1_gameover");
		}
		playerDisplay.UpdateLivesImage (lives);
		MoveToStartPoisiton();
	}
		
	private void MoveToStartPoisiton(){
		Vector3 startPosition = new Vector3 (0, 4, 0);
		transform.position = startPosition;
	}
		
}