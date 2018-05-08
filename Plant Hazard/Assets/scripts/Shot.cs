﻿using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	//Damage inflicted
	public int damage = 1;

	//Projectile damage player or enemies?
	public bool isEnemyShot = false;

	void Start(){
		//Limited time to live to avoid any leak
		Destroy(gameObject, 10); // 10sec
	}
}