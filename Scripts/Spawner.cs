using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemyPrefab;
	public GameObject[] turretPrefab;

	GameObject platforms;
	Transform[] platform;

	GameObject turrets;
	GameObject enemies;

	Turret newTurret;

	// Use this for initialization
	void Start () {

		turrets = GameObject.Find ("Turrets");

		platforms = GameObject.Find ("Platforms");
		platform = new Transform[platforms.transform.childCount];

		for (int i = 0; i < platforms.transform.childCount; i++) {
			platform[i] = platforms.transform.GetChild (i).transform;
		}
			
		SpawnTurret (0, 0);
		SpawnTurret (1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy(int type) {
		
	}

	void SpawnTurret(int index, int type) {
		newTurret = (Instantiate (turretPrefab [type], platform [index].position, platform [index].rotation, turrets.transform) as GameObject).GetComponent<Turret> ();
		newTurret.Init (platform [index]);
	}

}
