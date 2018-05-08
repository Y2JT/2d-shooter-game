using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	//Projectile prefab for shooting
	public Transform shotPrefab;

	//Cooldown in seconds between two shots
	public float shootingRate = 0.25f;

	//Cooldown
	private float shootCooldown;

	void Start(){
		shootCooldown = 0f;
	}

	void Update(){
		if (shootCooldown > 0){
			shootCooldown -= Time.deltaTime;
		}//end if
	}
		
	//Create a new projectile if possible
	public void Attack(bool isEnemy){
		if (CanAttack){
			shootCooldown = shootingRate;

			//Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			//Assign position
			shotTransform.position = transform.position;
			//The is enemy property
			Shot shot = shotTransform.gameObject.GetComponent<Shot>();
			if (shot != null){
				shot.isEnemyShot = isEnemy;
			}//end if

			//Make the weapon shot always towards it
			Move move = shotTransform.gameObject.GetComponent<Move>();
			if (move != null){
				move.direction = this.transform.right;
			}//end if
		}//end if
	}
		
	//Is the weapon ready to create a new projectile?
	public bool CanAttack{
		get{
			return shootCooldown <= 0f;
		}//end get
	}
}