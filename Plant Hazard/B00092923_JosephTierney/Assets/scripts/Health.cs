using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	//Total hitpoints
	public int hp = 1;

	//Enemy or player?
	public bool isEnemy = true;

	//Inflicts damage and check if the object should be destroyed
	public void Damage(int damageCount){
		hp -= damageCount;

		if (hp <= 0){
			//Dead!
			Destroy(gameObject);
		}//end if
	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		//Is this a shot?
		Shot shot = otherCollider.gameObject.GetComponent<Shot>();
		if (shot != null){
			//Avoid friendly fire
			if (shot.isEnemyShot != isEnemy){
				Damage(shot.damage);

				//Destroy the shot
				Destroy(shot.gameObject);
			}//end inner if
		}//end if
	}
}