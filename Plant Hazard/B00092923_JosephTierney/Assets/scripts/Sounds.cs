using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	public static Sounds Instance;

	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;
	public AudioClip dieSound;

	void Awake(){
		// Register the singleton
		if (Instance != null){
			Debug.LogError("Multiple instances of Sounds!");
		}
		Instance = this;
	}

	public void MakePlayerShotSound(){
		MakeSound(playerShotSound);
	}

	public void MakeEnemyShotSound(){
		MakeSound(enemyShotSound);
	}

	public void MakeDieSound(){
		MakeSound (dieSound);
	}

	//play sound
	private void MakeSound(AudioClip originalClip){
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
